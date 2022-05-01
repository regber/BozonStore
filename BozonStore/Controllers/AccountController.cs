using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models.UserModel;
using BozonStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BozonStore.ViewModels.Account;



namespace BozonStore.Controllers
{
    public class AccountController : Controller
    {
        private static User _user;
        private static ModelStateDictionary _modelState;

        ApplicationContext db;

        public AccountController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                if(user!=null)
                {
                    Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Не верно указан логин или пароль");
            }

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterBuyer(Buyer buyer)
        {
            CheckUser(ModelState, buyer);

            if (ModelState.IsValid)
            {
                db.Buyers.Add(buyer);
                db.SaveChanges();

                return View("RegistrationConfirm");
            }
            else
            {
                _user = buyer;
                _modelState = ModelState;
                return View("Register");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterSeller(Seller seller)
        {
            CheckUser(ModelState, seller);

            if (ModelState.IsValid)
            {
                db.Sellers.Add(seller);
                db.SaveChanges();

                return View("RegistrationConfirm");
            }
            else
            {
                _user = seller;
                _modelState = ModelState;
                return View("Register");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterDelivery(Delivery delivery)
        {
            CheckUser(ModelState, delivery);

            if (ModelState.IsValid)
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();

                return View("RegistrationConfirm");
            }
            else
            {
                return View("Register");
            }
        }

        public IActionResult UserTypeSelector(int userTypeId)
        {
            AddErrorsInToPartialView(ModelState);

            if (userTypeId == 0)
                return PartialView("_RegisterBuyer", _user);

            if (userTypeId == 1)
                return PartialView("_RegisterSeller", _user);

            if (userTypeId == 2)
                return PartialView("_RegisterDelivery", _user);

            return NotFound();
        }


        private void CheckUser(ModelStateDictionary modelState, User user)
        {
            if (CheckOccupiedEmail(user.Email))
                ModelState.AddModelError(nameof(user.Email), "Почта занята");
            if (CheckOccupiedLogin(user.Login))
                ModelState.AddModelError(nameof(user.Login), "Пользователь с таким логином уже есть");
        }
        private bool CheckOccupiedEmail(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }
        private bool CheckOccupiedLogin(string login)
        {
            return db.Users.Any(u => u.Login == login);
        }

        private void AddErrorsInToPartialView(ModelStateDictionary modelState)
        {
            var errors = _modelState?.ToList().Where(c => c.Value.Errors.Count > 0) ?? Enumerable.Empty<KeyValuePair<string, ModelStateEntry>>();

            foreach (var error in errors)
            {
                var key = error.Key;
                var errorMessage = error.Value.Errors?.FirstOrDefault().ErrorMessage.ToString();

                if (errorMessage != null)
                    ModelState.AddModelError(key, errorMessage);
            }
        }

        private void Authenticate(User user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.GetType().ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}

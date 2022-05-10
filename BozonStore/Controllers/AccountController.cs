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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BozonStore.Extension;
using Microsoft.AspNetCore.Mvc.Rendering;
using BozonStore.Common;





namespace BozonStore.Controllers
{
    public class AccountController : Controller
    {
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == StrToHashStr.Hash(model.Password));

                if(user!=null)
                {
                    Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Не верно указан логин или пароль");
                }
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
                Authenticate(buyer);

                return View("RegistrationConfirm");
            }
            else
            {
                TempData.Put("Buyer", buyer);
                TempData.Put("ModelState", ModelStateErrorToDic(ModelState));
                ViewData["defaultTypeId"] = 0;

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
                Authenticate(seller);

                return View("RegistrationConfirm");
            }
            else
            {
                TempData.Put("Seller", seller);
                TempData.Put("ModelState", ModelStateErrorToDic(ModelState));
                ViewData["defaultTypeId"] = 1;

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
                Authenticate(delivery);

                return View("RegistrationConfirm");
            }
            else
            {
                TempData.Put("Delivery", delivery);
                TempData.Put("ModelState", ModelStateErrorToDic(ModelState));
                ViewData["defaultTypeId"] = 2;

                return View("Register");
            }
        }

        public IActionResult UserTypeSelector(int userTypeId)
        {
            AddErrorsInToPartialView(ModelState);

            if (userTypeId == 0)
                return PartialView("_RegisterBuyer", TempData.Get<Buyer>("Buyer"));

            if (userTypeId == 1)
                return PartialView("_RegisterSeller", TempData.Get<Seller>("Seller"));

            if (userTypeId == 2)
                return PartialView("_RegisterDelivery", TempData.Get<Delivery>("Delivery"));

            return NotFound();
        }



        private void CheckUser(ModelStateDictionary modelState, User user)
        {
            if (CheckOccupiedEmail(user.Email))
                ModelState.AddModelError(nameof(user.Email), "Почта занята");

            if (CheckOccupiedLogin(user.Login))
                ModelState.AddModelError(nameof(user.Login), "Логин занят");

            if(user is Seller seller && CheckOccupiedSellerTitle(seller.Title))
                ModelState.AddModelError(nameof(seller.Title), "Продавец с таким названием уже есть");

            if (user is Delivery delivery && CheckOccupiedDeliveryTitle(delivery.Title))
                ModelState.AddModelError(nameof(delivery.Title), "Доставщик с таким названием уже есть");
        }
        private bool CheckOccupiedEmail(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }
        private bool CheckOccupiedLogin(string login)
        {
            return db.Users.Any(u => u.Login == login);
        }
        private bool CheckOccupiedSellerTitle(string sellerTitle)
        {
            return db.Sellers.Any(s => s.Title == sellerTitle);
        }
        private bool CheckOccupiedDeliveryTitle(string deliveryTitle)
        {
            return db.Deliveries.Any(d => d.Title == deliveryTitle);
        }
        private Dictionary<string,string> ModelStateErrorToDic(ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(key => key.Key, val => val.Value.Errors?.FirstOrDefault()?.ErrorMessage.ToString());
        }

        private void AddErrorsInToPartialView(ModelStateDictionary modelState)
        {
            var errors = TempData.Get<Dictionary<string,string>>("ModelState");

            if(errors!=null)
            {
                foreach (var error in errors)
                {
                    if(error.Value!=null)
                        ModelState.AddModelError(error.Key, error.Value);
                }
            }
        }

        private void Authenticate(User user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.GetType().Name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

    }

}

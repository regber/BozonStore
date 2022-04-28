using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models.UserModel;


namespace BozonStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Buyer buyer)
        {
            return Content("покупатель зарегестрирован");
        }
        [HttpPost]
        public IActionResult Register(Seller seller)
        {
            return Content("продавец зарегестрирован");
        }

        public IActionResult RegisterUser(int UserTypeId)
        {
            if(UserTypeId==0)
                return PartialView("_RegisterBuyer");
            if (UserTypeId == 1)
                return PartialView("_RegisterSeller");
            if (UserTypeId == 2)
                return PartialView("_RegisterDelivery");

            return NotFound();
        }

    }
}

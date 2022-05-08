using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BozonStore.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult PersonalPage()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;

            if (role == "Buyer")
            {
                return View("BuyerPage");
            }
            if (role == "Seller")
            {
                return View("SellerPage");
            }
            if (role == "Delivery")
            {
                return View("DeliveryPage");
            }

            return NotFound();
        }
    }
}

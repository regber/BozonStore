using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using Microsoft.AspNetCore.Authorization;


namespace BozonStore.Areas.User.Controllers
{
    [Area("user")]
    [Authorize(Roles ="Buyer")]
    public class BuyerController : Controller
    {
        ApplicationContext db;

        public BuyerController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProductToShopCart(int id)
        {

            //HttpContext.User.Identity.Name
            return Content(id.ToString());
        }
    }
}

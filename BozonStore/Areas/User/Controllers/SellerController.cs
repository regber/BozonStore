using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BozonStore.Controllers
{
    [Area("user")]
    [Authorize(Roles ="Seller")]
    public class SellerController : Controller
    {
        ApplicationContext db;
        public SellerController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Shops()
        {
            IEnumerable<Shop> shops = db.Shops.Where(s => s.Seller.Login == User.Identity.Name).ToList();
            
            return View(shops);
        }
        [HttpGet]
        public IActionResult CreateShop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateShop(Shop shop)
        {
            db.Sellers.Include(s=>s.Shops).FirstOrDefault(s => s.Login == User.Identity.Name).Shops.Add(shop);
            db.SaveChanges();

            return RedirectToAction("Shops");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BozonStore.Models.ProductModel;
using BozonStore.Extension;
using BozonStore.Areas.User.ViewsModel;

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
            var shops = db.Shops.Where(s => s.Seller.Login == User.Identity.Name);
            
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
            db.Sellers.Include(s=>s.Shops)
                      .FirstOrDefault(s => s.Login == User.Identity.Name)
                      .Shops.Add(shop);

            db.SaveChanges();

            return RedirectToAction("Shops");
        }

        [HttpGet]
        public IActionResult DeleteShop(int id)
        {
            var shop = db.Shops.FirstOrDefault(s => s.Id == id);

            return View(shop);
        }

        [HttpPost]
        [ActionName("DeleteShop")]
        public IActionResult DeleteThisShop(int id)
        {
            var shop = db.Shops.FirstOrDefault(s=>s.Id==id);

            db.Shops.Remove(shop);

            db.SaveChanges();

            return RedirectToAction(nameof(this.Shops));
        }

        [HttpGet]
        public IActionResult Shop(int id)
        {
            var seller = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id == id).Seller;
            
            if (seller.Login==User.Identity.Name)
            {
                TempData["ShopId"] = id;

                var shop = db.Shops.Include(s => s.Products)
                                   .ThenInclude(prod => prod.Images)
                                   .FirstOrDefault(s => s.Id == id);

                var shopProducts = new ShopProducts { ShopId = id, Products = shop.Products };


                return View(shopProducts);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

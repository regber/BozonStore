using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

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
            db.Sellers.Include(s=>s.Shops)
                      .FirstOrDefault(s => s.Login == User.Identity.Name)
                      .Shops.Add(shop);

            db.SaveChanges();

            return RedirectToAction("Shops");
        }
        [HttpGet]
        public IActionResult Shop(int id)
        {
            var seller = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id == id).Seller;

            if (seller.Login==User.Identity.Name)
            {
                                
                var shop = db.Shops.Include(s => s.Products)
                                   .ThenInclude(prod => prod.MainImage)
                                   .FirstOrDefault(s => s.Id == id);

                var products = shop.Products;

                return View(products);
            }
            else
            {
                return NotFound();
            }
            
            
        }
        public void DeleteProduct(int id)
        {
            db.Products.ToList().RemoveAt(id);
            db.SaveChanges();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
    }
}

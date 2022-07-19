using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


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

        public void AddProductToShopCart(int prodId)
        {
            var userLogin = HttpContext.User.Identity.Name;
            var buyer = db.Buyers.Include(b=>b.Purchases).ThenInclude(p=>p.Product).First(b => b.Login == userLogin);
            var prod = db.Products.Find(prodId);
            var shop = db.Shops.Include(s=>s.Seller).First(s => s.Products.Contains(prod));

            var purchases = buyer.Purchases;
            var purchProd = purchases.FirstOrDefault(p => p.Product.Id == prod.Id);

            if (purchProd!=null)
            {
                purchProd.Count++;
            }
            else
            {
                purchases.Add(new Purchase() { Product = prod, Seller = shop.Seller.Title, SellerShop = shop.Title, Count=1 });
            }
            
            db.SaveChanges();
        }
    }
}

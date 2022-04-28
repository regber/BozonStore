using BozonStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models.ProductModel;

using Microsoft.EntityFrameworkCore;

namespace BozonStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
            


            /*
            PurchaseSeller s = new PurchaseSeller
            {
                Login = "Regber2",
                Password = "bububaba",
                Name = "Stas",
                Title = "DNS",
                Email = "DNSShop@gmail.com",
                Address = "Kemerovo",
                NumberPhone = "88000563275"
            };


            db.PurchasSellers.Add(s);
            db.SaveChanges();*/
            /*
            PurchaseShop sh = new PurchaseShop { Address = "Kemerovo svobopdi", Seller = db.PurchasSellers.First(), Title = "DNS #1" };

            db.PurchasShops.Add(sh);
            db.SaveChanges();*/
            
            /*
            //var seller = db.PurchasSellers.Include(p => p.Shops).First();
            BozonStore.Models.ProductModel.Products.Electronics.Smartphone phone =
                new BozonStore.Models.ProductModel.Products.Electronics.Smartphone
                {
                    Title = "IPhone",
                    Discription = "Самый лучший телефон на свете",
                    Price = 100500,
                    BatteryVolume = 2000,
                    BodyMaterialType = "steel",
                    Color = new Models.ProductModel.CommonClass.Color { Alpha = 0, Blue = 50, Green = 50, Red = 50 },
                    CoreCount = 4,
                    Diagonal = 40,
                    EmbeddedMemoryVolume = 64,
                    HorizontalResolution = 1000,
                    VerticalResolution = 1600,
                    MemoryCardType = "SD",
                    RAMVolume = 4,
                    WirelessInterface = new string[] { "WiFi", "Internet", "Lan" },
                    //Shop= seller.Shops.First()

                };

            Purchase ph = new Purchase() { Product = phone };
            */

            //var seller = db.Sellers.Include(p=>p.Shops).First();
            //var shops = seller.Shops.First();
            //var products = shops.Products.ToList();
            //db.Products.Add(phone);
            //products.Add(phone);
            //db.Products.Add(phone);
            //db.Shops.FirstOrDefault().Products.Add(phone);
            //db.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

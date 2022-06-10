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
        }

        public IActionResult Search()
        {
            return View("Index");
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

        public JsonResult GetProducts()
        {
            var products = db.Products.Include(p=>p.Images);

            //var shop = db.Shops.Include(s => s.Products)
            //       .ThenInclude(prod => prod.Images)
            //       .FirstOrDefault(s => s.Id == id);

            return Json(products);
            //return Json(new {name="Stas",age="34" });
        }
    }
}

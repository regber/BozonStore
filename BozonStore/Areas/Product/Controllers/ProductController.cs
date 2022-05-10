using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using ProductModel=BozonStore.Models.ProductModel;
using Microsoft.AspNetCore.Authorization;

namespace BozonStore.Areas.Product.Controllers
{
    [Area("Product")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        ApplicationContext db;
        public ProductController(ApplicationContext context)
        {
            db = context;
        }

        public void DeleteProduct(int id)
        {
            db.Products.ToList().RemoveAt(id);
            db.SaveChanges();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel.Product prod)
        {
            return RedirectToAction();
        }
    }
}

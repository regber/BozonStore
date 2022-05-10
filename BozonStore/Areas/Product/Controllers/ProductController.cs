using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using ProductModel = BozonStore.Models.ProductModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using BozonStore.Models.PageModel;
using System.Reflection;

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
            ViewBag.ProdTypeSelectList = GetProdTypeSelectList();

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel.Product prod)
        {
            return RedirectToAction();
        }
        private SelectList GetProdTypeSelectList()
        {
            var interfaces = GetProdTypeInfo();

            var prodTypeList = new List<ProductType>();

            for (int i = 0; i < interfaces.Count(); i++)
            {
                var name = ((BozonStore.Common.InterfaceNameAnnotation)(interfaces[i]
                            .GetCustomAttributes(false)
                            .First(c => c.GetType() == typeof(BozonStore.Common.InterfaceNameAnnotation)))).Name;

                prodTypeList.Add(new ProductType { Id = i, ProdTypeName = name });
            }


            var selectList = new SelectList(prodTypeList, "Id", "ProdTypeName");
            return selectList;
        }
        private ArraySegment<TypeInfo> GetProdTypeInfo()
        {
            var interfaces = Assembly.GetEntryAssembly()
                                     .DefinedTypes
                                     .Where(t => t.FullName.Contains(nameof(BozonStore.Models.ProductModel.ProdTypeInterfaces)))
                                     .ToArray();

            return interfaces;
        }

    }
}

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
using BozonStore.Common;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

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
            var product = db.Products.Find(id);

            db.Products.Remove(product);
            db.SaveChanges();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var children = GetProdTypeInfo();
            ViewBag.SelectList = GenerateSelectList(children);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Dictionary<string, string> productFormProperties)
        {
            var shopId = (int)TempData["ShopId"];
            var seller = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id == shopId).Seller;


            if (seller.Login == User.Identity.Name)
            {
                if (ModelState.IsValid)
                {
                    var productType = Assembly.GetExecutingAssembly().GetType(productFormProperties["ProductType"]);

                    dynamic product = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(productFormProperties), productType);

                    db.Shops.Include(s => s.Products).FirstOrDefault(shop => shop.Id == shopId).Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Shop","Seller", new {id= shopId, area="user" });
                }
                else
                {
                    return RedirectToAction();
                }
            }
            else
            {
                return NotFound();
            }


        }

        public IActionResult PartialPage(string parentType)
        {
            var children = ExtraTypeInfo.GetFirstChildrenOfType(parentType);

            if(children.Count()>0)
            {
                ViewBag.SelectList = GenerateSelectList(children);

                return PartialView("_CreateSelector");
            }
            else
            {
                ViewBag.ProductType = parentType;
                return PartialView("_CreateForm");
            }
        }


        private ArraySegment<TypeInfo> GetProdTypeInfo()
        {
            var interfaces = Assembly.GetEntryAssembly()
                                     .DefinedTypes
                                     .Where(t => t.FullName.Contains(nameof(BozonStore.Models.ProductModel.ProdTypeInterfaces)))
                                     .ToArray();

            return interfaces;
        }
        private SelectList GenerateSelectList(IEnumerable<Type> types)
        {
            var prodTypeList = new List<ProductType>();

            foreach (var type in types)
            {
                var name = ExtraTypeInfo.GetDisplayName(type);

                prodTypeList.Add(new ProductType {TypeName = type.FullName, TypeDisplayName = name });
            }

            var selectList = new SelectList(prodTypeList,"TypeName", "TypeDisplayName");
            return selectList;
        }
    }
}

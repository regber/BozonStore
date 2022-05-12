﻿using Microsoft.AspNetCore.Mvc;
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
            var children = GetProdTypeInfo();
            ViewBag.SelectList = GenerateSelectList(children);

            return View();
        }


        [HttpPost]
        public IActionResult CreateProduct(Dictionary<string, string> productFormProperty)
        {
            var productType = Assembly.GetExecutingAssembly().GetType(productFormProperty["ProductType"]);

            dynamic product = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(productFormProperty), productType);

            db.Products.Add(product);
            db.SaveChanges();


            return RedirectToAction();
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

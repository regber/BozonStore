using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using BozonStore.Models.PageModel;
using System.Reflection;
using BozonStore.Common;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ProductModel = BozonStore.Models.ProductModel;
using BozonStore.Extension;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace BozonStore.Areas.Product.Controllers
{
    [Area("Product")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment env;

        public ProductController(ApplicationContext context, IWebHostEnvironment env)
        {
            db = context;
            this.env = env;
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
                    AddProductInToShop(shopId, productFormProperties);

                    return RedirectToAction("Shop", "Seller", new { id = shopId, area = "user" });
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

        private void AddProductInToShop(int shopId, Dictionary<string, string> productFormProperties)
        {
            var productType = Assembly.GetExecutingAssembly().GetType(productFormProperties["ProductType"]);

            dynamic product = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(productFormProperties), productType);

            db.Shops.Include(s => s.Products).FirstOrDefault(shop => shop.Id == shopId).Products.Add(product);
            db.SaveChanges();

            AddImagesInToProduct(product);

        }

        private void AddImagesInToProduct(ProductModel.Product product)
        {
            var productImages = TempData.Get<Dictionary<string, string>>("tempImages");

            var currentProduct = db.Products.Find(product.Id);

            List<Image> images = new List<Image>();

            foreach (var image in productImages)
            {
                CopyTempImageToProductAd(image, product);

                images.Add(new Image { Name = image.Key });
            }

            currentProduct.Images = images;

            db.SaveChanges();
            
        }
        private void CopyTempImageToProductAd(KeyValuePair<string, string> image, ProductModel.Product product)
        {
            var tempImagePath = image.Value;
            var newImageDirectory = env.ContentRootPath + "\\Content\\Ads\\" + product.Id;

            CreateDirIfItNotExist(newImageDirectory);

            var newImagePath = newImageDirectory + "\\" + image.Key;

            System.IO.File.Copy(tempImagePath, newImagePath);
        }
        private void CreateDirIfItNotExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IActionResult PartialPage(string parentType)
        {
            var children = ExtraTypeInfo.GetFirstChildrenOfType(parentType);

            if (children.Count() > 0)
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

                prodTypeList.Add(new ProductType { TypeName = type.FullName, TypeDisplayName = name });
            }

            var selectList = new SelectList(prodTypeList, "TypeName", "TypeDisplayName");
            return selectList;
        }

        [HttpPost]
        public async Task<IActionResult> UploadLargeFile()
         {
            var request = HttpContext.Request;

            // validation of Content-Type
            // 1. first, it must be a form-data request
            // 2. a boundary should be found in the Content-Type
            if (!request.HasFormContentType ||
                !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
            {
                return new UnsupportedMediaTypeResult();
            }

            var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
            var section = await reader.ReadNextSectionAsync();

            Dictionary<string, string> tempImages = new Dictionary<string, string>();

            // This sample try to get the first file from request and save it
            // Make changes according to your needs in actual use
            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                    out var contentDisposition);

                if (hasContentDispositionHeader && contentDisposition.DispositionType.Equals("form-data") &&
                    !string.IsNullOrEmpty(contentDisposition.FileName.Value))
                {
                    // Don't trust any file name, file extension, and file data from the request unless you trust them completely
                    // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
                    // In short, it is necessary to restrict and verify the upload
                    // Here, we just use the temporary folder and a random file name

                    // Get the temporary folder, and combine a random file name with it
                    var fileName = Path.GetRandomFileName();
                    var saveToPath = Path.Combine(Path.GetTempPath(), fileName);

                    tempImages.Add(contentDisposition.FileName.Value, saveToPath);

                    using (var targetStream = System.IO.File.Create(saveToPath))
                    {
                        await section.Body.CopyToAsync(targetStream);
                    }
                }

                section = await reader.ReadNextSectionAsync();

                if (section == null)
                {
                    TempData.Put("tempImages", tempImages);
                    return Ok();
                }
            }

            // If the code runs to this location, it means that no files have been saved
            return BadRequest("No files data in the request.");
        }
    }

}

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
using BozonStore.Areas.Product.ViewsModel;


namespace BozonStore.Areas.Product.Controllers
{
    [Area("Product")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private const string ContentAdsPath = "\\Content\\Ads\\";
        ApplicationContext db;
        IWebHostEnvironment env;

        public ProductController(ApplicationContext context, IWebHostEnvironment env)
        {
            db = context;
            this.env = env;
        }

        [HttpGet]
        public IActionResult EditProduct(int id, int shopId)
        {
            var product = db.Products.Include(p=>p.Images).FirstOrDefault(p => p.Id == id);
            var shop = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id == shopId);

            if (product==null || shop == null)
            {
                return NotFound();
            }

            if (shop.Seller.Login == User.Identity.Name)
            {
                ViewBag.ProductType = product.GetType().FullName;
                ViewBag.Product = product;

                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult EditProduct(Dictionary<string, string> productFormProperties)
        {

            var seller = db.Sellers.FirstOrDefault(s=>s.Login== User.Identity.Name);

            //if (seller.Login == User.Identity.Name)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        AddProductInToShop(shopId, productFormProperties);

            //        return RedirectToAction("Shop", "Seller", new { id = shopId, area = "user" });
            //    }
            //    else
            //    {
            //        return RedirectToAction();
            //    }
            //}
            //else
            //{
            //    return NotFound();
            //}
            return NotFound();
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id, int shopId)
        {
            var shop = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id== shopId);
            var product = db.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);

            if(shop==null|| product==null)
            {
                return NotFound();
            }

            if (shop.Seller.Login == User.Identity.Name)
            {
                var shopProduct = new ShopProduct { ShopId = shopId, Product = product };

                return View(shopProduct);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [ActionName("DeleteProduct")]
        public IActionResult DeleteProductPage(int id)
        {
            var product = db.Products.Find(id);
            var shop = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Products.Contains(product));

            var productContentPath = env.ContentRootPath + ContentAdsPath + product.Id;

            if (Directory.Exists(productContentPath))
            {
                Directory.Delete(productContentPath, true);
            }

            db.Products.Remove(product);
            db.SaveChanges();


            return RedirectToAction("Shop", "Seller", new { area = "User", id = shop.Id });


        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            if (TempData.ContainsKey("ShopId"))
            {
                var children = GetProdTypeInfo();
                ViewBag.SelectList = GenerateSelectList(children);

                return View();
            }
            else
            {
                var shops = db.Shops.Where(s => s.Seller.Login == User.Identity.Name);

                return RedirectToAction("Shops", "Seller", new { model = shops, area = "user" });
            }
        }


        [HttpPost]
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
            var productTempImages = TempData.Get<List<TempImage>>("tempImages");

            if(productTempImages==null)
            {
                return;
            }

            if(!productTempImages.Any(i=>i.MainImage))
            {
                productTempImages.FirstOrDefault().MainImage = true;
            }

            var currentProduct = db.Products.Find(product.Id);

            List<Image> images = new List<Image>();

            foreach (var tempImage in productTempImages)
            {
                CopyTempImageToProductAd(tempImage, product);

                if (tempImage.MainImage)
                {
                    images.Add(new Image { Name = tempImage.FileName, MainImage=true });
                }
                else
                {
                    images.Add(new Image { Name = tempImage.FileName, MainImage=false });
                }
            }


            currentProduct.Images = images;

            db.SaveChanges();

        }

        private void CopyTempImageToProductAd(TempImage tempImage, ProductModel.Product product)
        {
            var tempImagePath = tempImage.FilePath;
            var newImageDirectory = env.ContentRootPath + ContentAdsPath + product.Id;

            CreateDirIfItNotExist(newImageDirectory);

            var newImagePath = newImageDirectory + "\\" + tempImage.FileName;

            System.IO.File.Move(tempImagePath, newImagePath);
        }
        private void CreateDirIfItNotExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IActionResult ChildTypeView(string parentType)
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
        public async Task<IActionResult> UploadFile()
        {
            TempData.Remove("tempImages");

            var request = HttpContext.Request;

            if (!request.HasFormContentType ||
                !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
            {
                return new UnsupportedMediaTypeResult();
            }

            var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
            var section = await reader.ReadNextSectionAsync();

            List<TempImage> tempImages = new List<TempImage>();

            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                    out var contentDisposition);

                if (hasContentDispositionHeader && contentDisposition.DispositionType.Equals("form-data") &&
                    !string.IsNullOrEmpty(contentDisposition.FileName.Value))
                {
                    var fileName = Path.GetRandomFileName();
                    var saveToPath = Path.Combine(Path.GetTempPath(), fileName);

                    if (contentDisposition.Name == "mainImage")
                    {
                        tempImages.Add(new TempImage { FileName = contentDisposition.FileName.Value, FilePath = saveToPath, MainImage = true });
                    }
                    else
                    {
                        tempImages.Add(new TempImage { FileName = contentDisposition.FileName.Value, FilePath = saveToPath, MainImage = false });
                    }

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

            return BadRequest("No files data in the request.");
        }
    }

    class TempImage
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool MainImage { get; set; }
    }
}

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
using BozonStore.Areas.Product.Model;
using Newtonsoft.Json.Linq;


namespace BozonStore.Areas.Product.Controllers
{
    [Area("Product")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private const string ContentAdsPath = "\\Content\\Proposal\\";
        ApplicationContext db;
        IWebHostEnvironment env;


        public ProductController(ApplicationContext context, IWebHostEnvironment env)
        {
            db = context;
            this.env = env;
        }
        
        [AllowAnonymous]
        public JsonResult GetProdBunle(int bundleNumber,string queryFilters)
        {

            var bundleSize = 1000;
            var skipProdCount = bundleNumber * bundleSize;
            
            var products = GetProducts(queryFilters);

            var prodBundle = products.Where(p=>Filtration(p,queryFilters))
                                     .Skip(skipProdCount)
                                     .Take(bundleSize);

            
            return Json(prodBundle);
        }

        private IEnumerable<ProductModel.Product> GetProducts(string queryFilters)
        {
            JObject jsonFilters = JObject.Parse(queryFilters);
            JToken catalogType = null;

            if (jsonFilters.TryGetValue("catalogType", out catalogType))
            {
                var type = Assembly.GetEntryAssembly().GetTypes().First(t => t.Name == catalogType.Value<string>());
                var dependentTypes = ExtraTypeInfo.GetAllDependentTypeOfType(type);

                return ProdInfo.GetProductsByTypes(dependentTypes.ToArray());
            }
            else
            {
                return db.Products.AsNoTracking()
                                        .Include(p => p.Images)
                                        .AsEnumerable();
            }
        }



        private bool Filtration(ProductModel.Product prod, string queryFilters)
        {
            //переместить в отдельный метод
            var filters=JObject.Parse(queryFilters);

            foreach(var filter in filters.Children())
            {
                var filterItems=filter.Children<JToken>();

                foreach(var item in filterItems)
                {
                    if(item.Type==JTokenType.Array)
                    {
                        var itemName=item.Path;

                        var minItemValue= item[0].Value<string>();
                        var maxItemValue= item[1].Value<string>();

                        if(!CheckProperty(prod,itemName,minItemValue,maxItemValue))
                        {
                            return false;
                        }
                    }

                    if(item.Type== JTokenType.String)
                    {
                        var itemName = item.Path;
                        var itemValue = item.Value<string>();

                        if(!CheckProperty(prod,itemName,itemValue))
                        {
                            return false;
                        }
                    }
                }

            }


            return true;
        }

        private bool CheckProperty(ProductModel.Product prod,string propName, params string[] values)
        {
            if(!values.All(v=>v!=string.Empty))
            {
                return true;
            }

            var propValue=prod.GetType().GetProperties().FirstOrDefault(p=>p.Name.ToLower()==propName.ToLower())?.GetValue(prod,null);

            if(values.Count()==1)
            {
                if(propValue is int propValueInt)
                {
                    return int.Parse(values[0])==propValueInt;
                }
                if(propValue is string propValueStr)
                {
                    return propValueStr.ToLower().Contains(values[0].ToLower());
                }
                if(propValue is bool propValueBool)
                {
                    return bool.Parse(values[0]) == propValueBool;
                }
            }
            else
            {
                if(propValue is int propValueInt)
                {
                    var minValue=int.Parse(values[0]);
                    var maxValue=int.Parse(values[1]);

                    if(minValue>propValueInt || propValueInt>maxValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [HttpGet]
        public IActionResult EditProduct(int id, int shopId)
        {
            var product = db.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
            var shop = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id == shopId);

            if (product == null || shop == null)
            {
                return NotFound();
            }

            if (shop.Seller.Login == User.Identity.Name)
            {
                ViewBag.ProductType = product.GetType().FullName;
                ViewBag.Product = product;
                TempData["ShopId"] = shop.Id;

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

            var seller = db.Sellers.FirstOrDefault(s => s.Login == User.Identity.Name);

            var shopId = (int)TempData["ShopId"];

            if (seller.Login == User.Identity.Name)
            {
                if (ModelState.IsValid)
                {
                    EditProductInShop(shopId, productFormProperties);

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

        [HttpGet]
        public IActionResult DeleteProduct(int id, int shopId)
        {
            var shop = db.Shops.Include(s => s.Seller).FirstOrDefault(s => s.Id == shopId);
            var product = db.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);

            if (shop == null || product == null)
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
                var children = ProdInfo.GetProdTypeInfo();
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
        [AllowAnonymous]
        public IActionResult ViewProduct(int id)
        {
            var product = db.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.ProductType = product.GetType().FullName;
                ViewBag.Product = product;

                return View(product);
            }
        }

        private void EditProductInShop(int shopId, Dictionary<string, string> productFormProperties)
        {
            var productType = Assembly.GetExecutingAssembly().GetType(productFormProperties["ProductType"]);

            dynamic product = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(productFormProperties), productType);

            db.Products.Update(product);
            db.SaveChanges();

            AddImagesInToProduct(product);
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
            DeletePastProductImages(product.Id);

            var tempImages = TempData.Get<List<TempImage>>("tempImages");

            if (tempImages == null)
            {
                return;
            }

            if (!tempImages.Any(i => i.MainImage))
            {
                tempImages.FirstOrDefault().MainImage = true;
            }

            var currentProduct = db.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == product.Id);

            List<Image> images = new List<Image>();

            foreach (var tempImage in tempImages)
            {
                CopyTempImageToProduct(tempImage, product);

                if (tempImage.MainImage)
                {
                    images.Add(new Image { Name = tempImage.FileName, MainImage = true });
                }
                else
                {
                    images.Add(new Image { Name = tempImage.FileName, MainImage = false });
                }
            }

            currentProduct.Images = images;

            db.SaveChanges();

        }

        private void DeletePastProductImages(int prodId)
        {
            var imageDirectory = env.WebRootPath + ContentAdsPath + prodId;

            if(Directory.Exists(imageDirectory))
            {
                var pastFiles = Directory.GetFiles(imageDirectory);

                foreach (var file in pastFiles)
                {
                    System.IO.File.Delete(file);
                }
            }
        }

        private void CopyTempImageToProduct(TempImage tempImage, ProductModel.Product product)
        {
            var tempImagePath = tempImage.FilePath;
            var newImageDirectory = env.WebRootPath + ContentAdsPath + product.Id;

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
}

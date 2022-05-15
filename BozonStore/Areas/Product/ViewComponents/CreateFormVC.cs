using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using BozonStore.Models.ProductModel.Products.Electronics;
using System.Reflection;
using System.Linq;


namespace BozonStore.Areas.Product.Views.Product
{
    public class CreateFormVC : ViewComponent
    {

        public IViewComponentResult Invoke(string productType)
        {
            Type t = Assembly.GetExecutingAssembly().GetType(productType);
            
            MethodInfo method = typeof(CreateFormVC).GetMethod(nameof(CreateFormVC.GetView));
            MethodInfo generic = method.MakeGenericMethod(t);
            var view =(ViewViewComponentResult)generic.Invoke(this, null);

            return view;
        }

        public ViewViewComponentResult GetView<T>() where T:BozonStore.Models.ProductModel.Product
        {
            return View<T>(null);
        }
    }

}

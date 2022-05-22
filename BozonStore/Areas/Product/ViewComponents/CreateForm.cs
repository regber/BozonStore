using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using BozonStore.Models.ProductModel.Products.Electronics;
using System.Reflection;
using System.Linq;


namespace BozonStore.Areas.Product.Views.Product
{
    public class CreateForm : ViewComponent
    {

        public IViewComponentResult Invoke(string productType)
        {
            Type type = Assembly.GetExecutingAssembly().GetType(productType);
            
            MethodInfo method = typeof(CreateForm).GetMethod(nameof(CreateForm.GetView));
            MethodInfo generic = method.MakeGenericMethod(type);
            var view =(ViewViewComponentResult)generic.Invoke(this, null);

            return view;
        }

        public ViewViewComponentResult GetView<T>() where T:BozonStore.Models.ProductModel.Product
        {
            return View<T>(null);
        }
    }

}

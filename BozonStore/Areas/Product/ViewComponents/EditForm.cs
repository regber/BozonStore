using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;

namespace BozonStore.Areas.Product.ViewComponents
{
    public class EditForm:ViewComponent
    {
        public IViewComponentResult Invoke(string productType, object product)
        {
            Type type = Assembly.GetExecutingAssembly().GetType(productType);

            MethodInfo method = typeof(EditForm).GetMethod(nameof(EditForm.GetView));
            MethodInfo generic = method.MakeGenericMethod(type);
            var view = (ViewViewComponentResult)generic.Invoke(this, new object[] { product });

            return view;
        }

        public ViewViewComponentResult GetView<T>(T obj) where T : BozonStore.Models.ProductModel.Product
        {
            return View<T>(obj);
        }
    }
}

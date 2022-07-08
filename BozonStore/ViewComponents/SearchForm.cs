using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;

namespace BozonStore.ViewComponents
{
    public class SearchForm:ViewComponent
    {
        public IViewComponentResult Invoke(string productType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == productType);

            MethodInfo method = typeof(SearchForm).GetMethod(nameof(SearchForm.GetView));
            MethodInfo generic = method.MakeGenericMethod(type);
            var view = (ViewViewComponentResult)generic.Invoke(this, null);

            return view;
        }

        public ViewViewComponentResult GetView<T>() where T : BozonStore.Models.ProductModel.Product
        {
            return View<T>(null);
        }
    }
}

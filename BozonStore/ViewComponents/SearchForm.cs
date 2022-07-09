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
            Type type = null;
            MethodInfo generic = null;
            MethodInfo method=null;
            ViewViewComponentResult view;

            //Если тип дает возможность создать свой экземляр
            try
            {
                type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == productType);
                method = typeof(SearchForm).GetMethod(nameof(SearchForm.GetView));
                generic = method.MakeGenericMethod(type);
            }
            //Если тип не дает возможности создать собственный экземпляр, например в качестве типа передан интерфейс
            catch
            {
                type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == nameof(BozonStore.Models.ProductModel.Product));
                method = typeof(SearchForm).GetMethod(nameof(SearchForm.GetView));
                generic = method.MakeGenericMethod(type);
            }
            finally
            {
                view = (ViewViewComponentResult)generic.Invoke(this, null);
            }

            return view;
        }

        public ViewViewComponentResult GetView<T>() where T : BozonStore.Models.ProductModel.Product
        {
            return View<T>(null);
        }
    }
}

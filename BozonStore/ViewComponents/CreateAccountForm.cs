using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;
using Newtonsoft.Json;

namespace BozonStore.ViewComponents
{
    public class CreateAccountForm:ViewComponent
    {
        public IViewComponentResult Invoke(string userType,BozonStore.Models.UserModel.User user)
        {
            Type type = Assembly.GetExecutingAssembly().GetType(userType);

            MethodInfo method = typeof(CreateAccountForm).GetMethod(nameof(CreateAccountForm.GetView));
            MethodInfo generic = method.MakeGenericMethod(type);

            var view = (ViewViewComponentResult)generic.Invoke(this,new object[] {user} );

            ViewData["UserType"]= type.FullName;

            return view;
        }

        public ViewViewComponentResult GetView<T>(T user) where T : BozonStore.Models.UserModel.User
        {
            return View<T>(user);
        }
    }
}

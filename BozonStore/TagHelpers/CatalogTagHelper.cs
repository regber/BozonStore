using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using BozonStore.Models.ProductModel;
using System.Reflection;


namespace BozonStore.TagHelpers
{
    public class CatalogTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            SetCatalog();
        }

        private void SetCatalog()
        {

            var childTypes = Assembly.GetExecutingAssembly()
                                .GetTypes().Where(t => t.BaseType == typeof(Product));
                                //.Where(t => t.GetInterfaces().Any(i => i.FullName == parentTypeName) ||
                                //            t.BaseType?.FullName == parentTypeName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace BozonStore.Common
{
    public static class ProdInfo
    {
        public static ArraySegment<TypeInfo> GetProdTypeInfo()
        {
            var interfaces = Assembly.GetEntryAssembly()
                                     .DefinedTypes
                                     .Where(t => t.FullName.Contains(nameof(BozonStore.Models.ProductModel.ProdTypeInterfaces)))
                                     .ToArray();

            return interfaces;
        }

        public static string GetProdLimitValues(string productType)
        {
            var type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t=>t.Name== productType);

            var properties = Assembly.GetEntryAssembly()
                                      .DefinedTypes
                                      .Where(t => t.IsSubclassOf(type));//t.GetNestedTypes()

            //var b = properties.GetNestedTypes();
            return "";
        }
    }


}

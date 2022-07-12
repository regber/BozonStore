using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json.Linq;
using BozonStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BozonStore.Common
{
    public static class ProdInfo
    {
        static ApplicationContext db;

        static ProdInfo()
        {
            string connectString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectString);

            db = new ApplicationContext(optionsBuilder.Options);
        }

        public static ArraySegment<TypeInfo> GetProdTypeInfo()
        {
            var interfaces = Assembly.GetEntryAssembly()
                                     .DefinedTypes
                                     .Where(t => t.FullName.Contains(nameof(BozonStore.Models.ProductModel.ProdTypeInterfaces)))
                                     .ToArray();

            return interfaces;
        }

        public static JObject GetProdPropLimitValues(string productType, IEnumerable<PropertyInfo> properties)
        {
            var type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t=>t.Name== productType);

            var childrenTypes = ExtraTypeInfo.GetLastChildrenOfType(type);

            var products = GetProductsByTypes(childrenTypes.ToArray());

            JObject json = new JObject();



            foreach(var prop in properties)
            {
                if(prop.PropertyType==typeof(int))
                {
                    int min = GetProductsMinPropertyValue<int>(prop.Name, products);
                    int max = GetProductsMaxPropertyValue<int>(prop.Name, products);

                    json.Add(prop.Name + "Min", min);
                    json.Add(prop.Name + "Max", max);
                }
            }
            
            return json;
        }

        private static T GetProductsMinPropertyValue<T>(string propertyName, IEnumerable<BozonStore.Models.ProductModel.Product> products) where T: IComparable
        {
            //учесть вариант когда в products.count()==0
            if(products.Count()>0)
            {
                return products.Select(p => (T)p.GetType()
                                                .GetProperty(propertyName)
                                                .GetValue(p))
                                                .Min();
            }
            else
            {
                return default(T);
            }

        }
        private static T GetProductsMaxPropertyValue<T>(string propertyName, IEnumerable<BozonStore.Models.ProductModel.Product> products) where T : IComparable
        {
            //учесть вариант когда в products.count()==0
            if (products.Count() > 0)
            {
                return products.Select(p => (T)p.GetType()
                                                .GetProperty(propertyName)
                                                .GetValue(p))
                                                .Max();
            }
            else
            {
                return default(T);
            }
        }

        public static IEnumerable<PropertyInfo> GetProperyListOfType(Type type)
        {
            var properties = type.GetProperties();

            return properties;
        }

        private static IEnumerable<Models.ProductModel.Product> GetProductsByTypes(params Type[] types)
        {
            var products = db.Products.AsNoTracking().ToList();

            products = products.Where(t => types.Any(T => T.Name == t.GetType().Name)).ToList();

            return products;
        }

        //private static void Get


    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BozonStore.Common
{
    public static class ExtraTypeInfo
    {
        private static string GetClassDisplayName(Type type)
        {
            string name = ((System.ComponentModel.DataAnnotations.DisplayAttribute)type
                        .GetCustomAttributes(false)
                        .First(c => c.GetType() == typeof(System.ComponentModel.DataAnnotations.DisplayAttribute))).Name;

            return name == null ? string.Empty : name;
        }
        private static string GetInterfaceDisplayName(Type type)
        {
            string name = ((BozonStore.Common.InterfaceDisplayAttribute)(type
                            .GetCustomAttributes(false)
                            .First(c => c.GetType() == typeof(BozonStore.Common.InterfaceDisplayAttribute)))).Name;

            return name == null ? string.Empty : name;
        }
        public static string GetDisplayName(Type type)
        {
            if (type.IsClass)
            {
                return GetClassDisplayName(type);
            }
            else if (type.IsInterface)
            {
                return GetInterfaceDisplayName(type);
            }
            else
            {
                return string.Empty;
            }
        }
        public static IEnumerable<Type> GetFirstChildrenOfType(string parentTypeName)
        {
            var children = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(t => t.GetInterfaces().Any(i => i.Name == parentTypeName) ||
                                               t.BaseType?.Name == parentTypeName);

            return children == null ? Enumerable.Empty<Type>() : children;
        }
    }
}

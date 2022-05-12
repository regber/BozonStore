using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Common
{
    public static class ExtraTypeInfo
    {
        private static string GetClassDisplayName(Type type)
        {
            string name = ((type.GetCustomAttributes(false)
                                .FirstOrDefault(c => c.GetType() == typeof(DisplayAttribute))) as DisplayAttribute)?.Name;

            return name == null ? string.Empty : name;
        }
        private static string GetInterfaceDisplayName(Type type)
        {
            string name = (type.GetCustomAttributes(false)
                               .FirstOrDefault(c => c.GetType() == typeof(InterfaceDisplayAttribute)) as InterfaceDisplayAttribute)?.Name;

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
                                   .Where(t => t.GetInterfaces().Any(i => i.FullName == parentTypeName) ||
                                               t.BaseType?.FullName == parentTypeName);

            return children == null ? Enumerable.Empty<Type>() : children;
        }
    }
}

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
            var childTypes = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => t.GetInterfaces().Any(i=>i.FullName == parentTypeName) || 
                                            t.BaseType?.FullName == parentTypeName);
            
            var firstChildren = childTypes.Where(t => !childTypes.Contains(t.BaseType));

            return firstChildren == null ? Enumerable.Empty<Type>() : firstChildren;
        }

        public static IEnumerable<Type> GetFirstChildrenOfType(Type type)
        {
            var childrenTypes = GetFirstChildrenOfType(type.FullName);

            return childrenTypes;
        }

        private static IEnumerable<Type> GetLastChildrenOfType(Type type)
        {
            var types = Assembly.GetEntryAssembly().GetTypes();

            var lastChildren = types.Where(t1 => (TypeIsChildOfType(t1,type)) && !TypeHasChild(t1));

            return lastChildren == null ? Enumerable.Empty<Type>() : lastChildren;
        }

        public static IEnumerable<Type> GetAllDependentTypeOfType(Type type)
        {
            List<Type> types=new List<Type>(GetLastChildrenOfType(type));

            if(!TypeHasChild(type))
            {
                types.Add(type);
            }

            return types;
        }

        private static bool TypeHasChild(Type type)
        {
            var types = Assembly.GetEntryAssembly().GetTypes();

            return types.Where(t => t.IsSubclassOf(type) || t.GetInterfaces().Any(t => t == type)).Count() > 0;
        }

        private static bool TypeIsChildOfType(Type childType, Type baseType)
        {
            return (childType.IsSubclassOf(baseType) || childType.GetInterfaces().Any(t => t == baseType));
        }
    }
}

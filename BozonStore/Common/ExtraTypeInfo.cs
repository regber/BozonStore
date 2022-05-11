using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Common
{
    public class AnnotationName
    {
        private static string GetDisplayName(Type type)
        {
            string name = ((System.ComponentModel.DataAnnotations.DisplayAttribute)type
                        .GetCustomAttributes(false)
                        .First(c => c.GetType() == typeof(System.ComponentModel.DataAnnotations.DisplayAttribute))).Name;

            return name == null ? string.Empty : name;
        }
        private static string GetInterfaceDisplayName(Type type)
        {
            string name = ((BozonStore.Common.InterfaceNameAnnotation)(type
                            .GetCustomAttributes(false)
                            .First(c => c.GetType() == typeof(BozonStore.Common.InterfaceNameAnnotation)))).Name;

            return name == null ? string.Empty : name;
        }
        public static string Get(Type type)
        {
            if (type.IsClass)
            {
                return GetDisplayName(type);
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
    }
}

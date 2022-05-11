using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Common
{
    [System.AttributeUsage(System.AttributeTargets.Interface)]
    public class InterfaceDisplayAttribute : System.Attribute
    {
        public InterfaceDisplayAttribute(string Name)
        {
            this.Name = Name;
        }

        public string Name{get;set;}
    }
}

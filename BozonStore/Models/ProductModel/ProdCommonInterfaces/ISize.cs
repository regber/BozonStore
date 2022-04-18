using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models.ProductModel.ProdCommonInterfaces
{
    interface ISize
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }
    }
}

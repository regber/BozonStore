using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models.ProductModel;

namespace BozonStore.Areas.Product.ViewsModel
{
    public class ShopProduct
    {
        public int ShopId { get; set; }
        public BozonStore.Models.ProductModel.Product Product { get; set; }
    }
}

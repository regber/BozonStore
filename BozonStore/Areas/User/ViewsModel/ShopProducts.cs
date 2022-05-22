using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Areas.User.ViewsModel
{
    public class ShopProducts
    {
        public int ShopId { get; set; }
        public IEnumerable<Models.ProductModel.Product> Products { get; set; }
    }
}

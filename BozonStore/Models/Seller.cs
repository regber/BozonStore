using System;
using System.Collections.Generic;
using System.Linq;
using BozonStore.Models.CommonInterface;
using BozonStore.Models.ProductModel;

namespace BozonStore.Models
{
    public class Seller : User, ISeller<Shop>
    {
        public string Title { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}

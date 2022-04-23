using System.Collections.Generic;
using BozonStore.Models.ProductModel;

namespace BozonStore.Models
{
    public class SellerShop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public int SellerId {get;set;}
        public Seller Seller { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

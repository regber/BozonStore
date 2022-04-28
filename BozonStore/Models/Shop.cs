using System.Collections.Generic;
using BozonStore.Models.ProductModel;
using BozonStore.Models.UserModel;

namespace BozonStore.Models
{
    public class Shop
    {
        public int Id { get; set; }


        public string Title { get; set; }
        public string Address { get; set; }


        public int SellerId { get; set; }
        public Seller Seller { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}

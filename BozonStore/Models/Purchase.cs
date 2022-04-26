using BozonStore.Models;
using BozonStore.Models.ProductModel;


namespace BozonStore.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        
        public string Seller { get; set; }
        public string SellerShop { get; set; }
    }
}

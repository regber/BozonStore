using BozonStore.Models.ProductModel;

namespace BozonStore.Models
{
    public class Purchas
    {
        public int Id { get; set; }

        public BaseProduct Product { get; set; }
        public Seller Seller { get; set; }
        public SellerShop SellerShop { get; set; }
    }
}

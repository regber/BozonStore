using BozonStore.Models.PurchasModel;


namespace BozonStore.Models
{
    public class Purchas
    {
        public int Id { get; set; }

        public PurchasProduct Product { get; set; }
        public PurchasSeller Seller { get; set; }
        public PurchasSellerShop SellerShop { get; set; }
    }
}

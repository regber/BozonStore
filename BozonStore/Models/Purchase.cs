using BozonStore.Models.PurchaseModel;


namespace BozonStore.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public PurchaseProduct Product { get; set; }
        public PurchaseSeller Seller { get; set; }
        public PurchaseShop SellerShop { get; set; }
    }
}

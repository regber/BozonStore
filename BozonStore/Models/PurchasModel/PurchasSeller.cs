using System.Collections.Generic;

namespace BozonStore.Models.PurchasModel
{
    public class PurchasSeller : Seller
    {
        public new string Title { get; set; }
        public new ICollection<PurchasSellerShop> SellersShops { get; set; }
    }
}

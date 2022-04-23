using BozonStore.Models;

using System.Collections.Generic;

namespace BozonStore.Models.PurchasModel
{
    public class PurchasSellerShop:SellerShop
    {
        public new int SellerId { get; set; }
        public new PurchasSeller Seller { get; set; }

        public new ICollection<PurchasProduct> Products { get; set; }
    }
}

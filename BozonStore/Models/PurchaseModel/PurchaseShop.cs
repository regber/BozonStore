using BozonStore.Models;
using BozonStore.Models.CommonInterface;
using System.Collections.Generic;

namespace BozonStore.Models.PurchaseModel
{
    public class PurchaseShop : IShop<PurchaseSeller, PurchaseProduct>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int SellerId { get; set; }
        public PurchaseSeller Seller { get; set; }
        public ICollection<PurchaseProduct> Products { get; set; }
    }
}

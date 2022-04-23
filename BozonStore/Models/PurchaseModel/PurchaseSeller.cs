using System.Collections.Generic;
using BozonStore.Models.CommonInterface;

namespace BozonStore.Models.PurchaseModel
{
    public class PurchaseSeller :User, ISeller<PurchaseShop>

    {
        public string Title { get; set; }
        public ICollection<PurchaseShop> Shops { get; set; }
    }
}

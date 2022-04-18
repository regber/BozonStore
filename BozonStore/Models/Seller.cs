using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }

        public ICollection<SellerShop> SellersShops { get;set;}
    }
}

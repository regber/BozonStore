using System.Collections.Generic;


namespace BozonStore.Models.CommonInterface
{
    interface IShop<SelleR,Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public int SellerId { get; set; }
        public SelleR Seller { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

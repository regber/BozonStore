using System.Collections.Generic;

namespace BozonStore.Models.ProductModel
{
    public abstract class BaseProduct
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }


        public string MainImagePath { get; set; }
        public ICollection<string> ImagesPaths { get; set; }


        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}

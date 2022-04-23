using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Collections.Generic;

namespace BozonStore.Models.PurchaseModel
{
    public class PurchaseProduct : IBaseProduct<PurchaseSeller>
    {
        public int Id { get; set; }


        public string Title { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }


        public Image MainImage { get; set; }
        public ICollection<Image> Images { get; set; }


        public int SellerId { get; set; }
        public PurchaseSeller Seller { get; set; }
    }
}

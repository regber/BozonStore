using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Collections.Generic;

namespace BozonStore.Models.PurchaseModel
{
    public class PurchaseProduct : IBaseProduct<PurchaseSeller,PurchaseImage>
    {
        public int Id { get; set; }


        public string Title { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }


        public PurchaseImage MainImage { get; set; }
        public ICollection<PurchaseImage> Images { get; set; }


        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}

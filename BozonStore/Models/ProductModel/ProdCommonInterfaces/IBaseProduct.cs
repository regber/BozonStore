using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models.ProductModel.ProdCommonInterfaces
{
    interface IBaseProduct
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }


        public Image MainImage { get; set; }
        public ICollection<Image> Images { get; set; }


        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}

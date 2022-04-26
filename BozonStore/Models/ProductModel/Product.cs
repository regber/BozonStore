using System.Collections.Generic;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;



namespace BozonStore.Models.ProductModel
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }


        public Image MainImage { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}

﻿using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Collections.Generic;

namespace BozonStore.Models.PurchasModel
{
    public class PurchasProduct : IBaseProduct
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

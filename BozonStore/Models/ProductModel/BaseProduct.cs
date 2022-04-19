﻿using System.Collections.Generic;
using System.Drawing;



namespace BozonStore.Models.ProductModel
{
    public class BaseProduct
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

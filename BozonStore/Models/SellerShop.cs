﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models
{
    public class SellerShop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public int SellerId {get;set;}
        public Seller Seller { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class ProductSale
    {
        [Key]
        public int idPS { get; set; }
        public string namePS { get; set; }
        public string descriptionPS { get; set; }
        public decimal? priceSalePS { get; set; }
        public decimal? salePSPhanTram { set; get; }
        public int quantityPS { get; set; }
        public DateTime dateStartSale { get; set; }
        public DateTime dateEndSale { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Voucher
    {
        [Key]
        public int idVoucher { get; set; }
        public string nameVoucher { get; set; }
        public string descriptionVoucher { get; set; }
        public double priceVoucher { get; set; }
        public int quantityVoucher { get; set; }
        public DateTime dateStartVoucher { get; set; }
        public DateTime dateEndVoucher { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Payment
    {
        [Key]
        public int idPayment { get; set; }
        public DateTime datePayment { get; set; }
        public string descriptionPayment { get; set; }
        public double totalMoney { get; set; }
    }
}
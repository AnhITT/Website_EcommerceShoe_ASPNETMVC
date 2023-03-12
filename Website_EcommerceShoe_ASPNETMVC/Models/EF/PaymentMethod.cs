using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class PaymentMethod
    {
        [Key]
        public int idMethod { get; set; }
        public string nameMethod { get; set; }
    }
}
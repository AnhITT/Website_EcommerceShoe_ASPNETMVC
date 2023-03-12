using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Cart
    {
        [Key]
        public int idCart { get; set; }
        public int quantityCart { get; set; }
        public string nameCart { get; set; }
        public int? PaymentMethodId { get; set; }
        public virtual PaymentMethod IdPaymentMethod { get; set; }
    }
}
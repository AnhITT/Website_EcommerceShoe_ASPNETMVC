using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class ImagesProduct
    {
        [Key]
        public int idImg { get; set; }
        public string urlImg { get; set; }
        public int? productID { get; set; }
        public virtual Product Product { get; set; }

    }
}
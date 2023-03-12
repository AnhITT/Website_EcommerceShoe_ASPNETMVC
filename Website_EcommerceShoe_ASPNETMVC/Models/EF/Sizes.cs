using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Sizes
    {
        [Key]
        public int idSize { get; set; }
        public string nameSize { get; set; }
        public int quantitySize { get; set; }
    }
}
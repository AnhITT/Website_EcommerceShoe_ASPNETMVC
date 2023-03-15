using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Brand
    {
        [Key]
        public int idBrand { get; set; }
        public string nameBrand { get; set; }
        

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Feedback
    {
        [Key]
        public int idFB { get; set; }
        public double ratingFB { get; set; }
        public string titleFB { get; set; }
        public string descriptionFB { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Blog
    {
        [Key]
        public int idBlog { get; set; }
        public string titleBlog { get; set; }
        public string descriptionBlog { get; set; }
        public DateTime dateSubmitted { get; set; }
    }
}
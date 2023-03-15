using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public DateTime dateUpProduct { get; set; }
        public string descriptionProduct { get; set; }
        public string UrlImgCover { get; set; }
        public string UrlImgCover_After { get; set; }
        public double priceProduct { get; set; }
        public bool statusProduct { get; set; }
        public virtual ICollection<ImagesProduct> IdImg { get; set; }
        public virtual ICollection<ProductSale> IdSale { get; set; }
        public int? idCar { get; set; }

        public virtual Category Category { get; set; }
        public int? idBrand { get; set; }

        public virtual Brand Brand { get; set; }


    }
}
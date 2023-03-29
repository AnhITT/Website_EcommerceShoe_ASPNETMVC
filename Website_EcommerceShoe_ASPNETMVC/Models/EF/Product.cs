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
        public string descriptionProduct { get; set; }
        public string UrlImgCover { get; set; }

        public int ViewCount { get; set; }
        public decimal priceProduct { get; set; }
        public bool statusProduct { get; set; }
        public virtual ICollection<ImagesProduct> IdImg { get; set; }
        public virtual ICollection<ProductSale> IdSale { get; set; }
        public virtual ICollection<Sizes> IdSize { get; set; }
        public int? idCar { get; set; }
        public virtual Category Category { get; set; }
        public int? idBrand { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ImagesProduct ImagesProduct { get; set; }
        public virtual Sizes Sizes { get; set; }
        public int? idPSale { get; set; }
        public virtual ProductSale ProductSale { get; set; }
    }
}
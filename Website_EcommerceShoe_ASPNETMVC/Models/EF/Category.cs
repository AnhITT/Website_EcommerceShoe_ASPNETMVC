﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Category
    {
        [Key]
        public int idCar { get; set; }
        public string nameCar { get; set; }
        public string descriptionCar { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}
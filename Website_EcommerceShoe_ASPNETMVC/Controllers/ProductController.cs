using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;

namespace Website_EcommerceShoe_ASPNETMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;
        // GET: Product
        public ActionResult Index()
        {
            return View(data.Products.ToList());
        }
    }
}
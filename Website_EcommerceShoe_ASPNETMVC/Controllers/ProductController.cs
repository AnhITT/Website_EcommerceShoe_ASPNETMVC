using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;
        public ProductController()
        {
            data = new ApplicationDbContext();
        }
        // GET: Product
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(data.Products.ToList().ToPagedList(pageNum, pageSize));
        }

        public ActionResult Detail(int id)
        {
            Product item = data.Products.Find(id);
            return View(item);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        private readonly ApplicationDbContext data;

        public AdminController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var currentUser = HttpContext.User;
            var name = currentUser.Identity.Name;
            ViewBag.id = name;

            ViewBag.Titlee = "Trang quản lý";
            ViewBag.countProduct = data.Products.Count();
            ViewBag.toTalProductsActivate = data.Products.Count(a => a.statusProduct == true);
            ViewBag.toTalProductsDeAct = data.Products.Count(a => a.statusProduct == false);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
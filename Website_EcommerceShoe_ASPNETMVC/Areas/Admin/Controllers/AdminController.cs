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
                ViewBag.totalLoiNhuan = data.Orders.Sum(n => n.TotalAmount);
                ViewBag.totalOrder = data.Orders.Count();
            ViewBag.Titlee = "Trang quản lý";
            ViewBag.countProduct = data.Products.Count();
            ViewBag.toTalProductsActivate = data.Products.Count(a => a.statusProduct == true);
            ViewBag.toTalProductsDeAct = data.Products.Count(a => a.statusProduct == false);
            ViewBag.toTalAccount = data.Users.Count();

            //Best View
            var index = data.Products.Max(a => a.ViewCount);
            ViewBag.maxProduct = index;
            var item = data.Products.Where(data => data.ViewCount == index);
            foreach (var i in item)
            {
                ViewBag.maxProductView = i.nameProduct;
            }
            //End Best View

            //Best Seller
            var namePR = 0;
            int spmax = 0;
            var ac = data.OrderDetails.ToList();
            foreach (var i in ac)
            {
                var sp = ac.Where(n => n.ProductId == i.ProductId).ToList();
                foreach(var j in sp)
                {
                    var sl = sp.Sum(n => n.Quantity);
                    if (sl > spmax) 
                    {
                        spmax = sl;
                        namePR = j.ProductId;
                    }
                }
            }
            var result = data.Products.Where(n => n.idProduct == namePR).FirstOrDefault();
            ViewBag.SPBanNhieuNhat = result.nameProduct;
            ViewBag.slSP = spmax;
            //End Best Seller
            return View();
        }

        
    }
}
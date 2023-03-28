using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;


namespace Website_EcommerceShoe_ASPNETMVC.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        private readonly ApplicationDbContext data;
        public UserController()
        {
            data = new ApplicationDbContext();
        }
        public void GetInfomationUser()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.User = user;
        }
        public ActionResult QLInformation()
        {
            GetInfomationUser();
            return View();
        }

        public ActionResult EditInformationUser()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                UpdateModel(user);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult QLOrder()
        {
            var id = User.Identity.GetUserId();
            var item = data.Orders.Where(n => n.idCustomer == id);
            return View(item);
        }

        public ActionResult Detail(int id)
        {
            IList<OrderDetail> item = data.OrderDetails.Where(n => n.OrderId == id).ToList();
            return View(item);
        }

        [HttpGet]
        public ActionResult CancelOrder(int id)
        {
            var item = data.Orders.Find(id);
            return View(item);
        }
        [HttpPost, ActionName("CancelOrder")]
        public ActionResult ComfirmCancel(int id)
        {
            var item = data.Orders.Find(id);
            var itemDetail = data.OrderDetails.Where(n => n.OrderId == id).ToList();
            if (item != null && itemDetail != null)
            {
                data.Orders.Remove(item);
                foreach (var item1 in itemDetail)
                {
                    data.OrderDetails.Remove(item1);
                }
                data.SaveChanges();
            }
            return RedirectToAction("QLOrder");
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
        [HttpPost]
        public ActionResult EditInformationUser(HttpPostedFileBase fileupload)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                if (fileupload != null && fileupload.ContentLength > 0)
                {
                    //lấy tên file được tải lên từ form upload và lưu vào biến fileName.
                    var fileName = Path.GetFileName(fileupload.FileName);

                    //Chứa đường dẫn
                    var path = Path.Combine(Server.MapPath("~/Content/Image/Avatar/"), fileName);

                    //Lưu file
                    fileupload.SaveAs(path);
                    user.Avartar = fileName;
                    UpdateModel(user);
                    data.SaveChanges();
                    return RedirectToAction("QLInformation");
                }
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
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class QLVoucherController : Controller
    {
        // GET: Admin/QLVoucher
        private readonly ApplicationDbContext data;

        public QLVoucherController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult QLVoucher(int? page)
        {
            ViewBag.Titlee = "Quản lý Voucher";
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(data.Vouchers.ToList().ToPagedList(pageNum, pageSize));
        }

        public ActionResult AddVoucher()
        {
            ViewBag.Titlee = "Thêm Voucher";
            return View();
        }

        [HttpPost]
        public ActionResult AddVoucher(Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                data.Vouchers.Add(voucher);
                data.SaveChanges();
                return RedirectToAction("QLVoucher");
            }
            return RedirectToAction("QLVoucher");
        }
    }
}
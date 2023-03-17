using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        private readonly ApplicationDbContext data;
        public BrandController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            ViewBag.Titlee = "Quản lý nhãn hàng";
            return View(data.Brands.ToList().ToPagedList(pageNum, pageSize));
        }
        
        public ActionResult AddBrand()
        {
            ViewBag.Titlee = "Thêm nhãn hàng";
            return View();
        }

        [HttpPost]
        public ActionResult AddBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                data.Brands.Add(brand);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditBrand(int id)
        {
            Brand brand = data.Brands.Find(id);
            return View(brand);
        }
        [HttpPost]
        public ActionResult EditBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                data.Entry(brand).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = data.Brands.Find(id);
            if (item != null)
            {
                data.Brands.Remove(item);
                data.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
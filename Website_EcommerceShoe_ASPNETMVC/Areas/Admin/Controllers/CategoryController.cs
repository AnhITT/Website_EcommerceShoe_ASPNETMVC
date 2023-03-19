using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private readonly ApplicationDbContext data;
        public CategoryController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            ViewBag.Titlee = "Quản lý danh mục";
            return View(data.Categories.ToList().ToPagedList(pageNum, pageSize));
        }

        public ActionResult AddCategory()
        {
            ViewBag.Titlee = "Thêm danh mục";
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category sp)
        {
            if (ModelState.IsValid)
            {
                data.Categories.Add(sp);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditCategory(int id)
        {
            ViewBag.Titlee = "Sửa danh mục";
            Category category = data.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                data.Entry(category).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = data.Categories.Find(id);
            if (item != null)
            {
                data.Categories.Remove(item);
                data.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult ListCategory(int? page, int id)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            ViewBag.dangBan = "Đang bán";
            ViewBag.tamNgung = "Tạm ngưng";
            ViewBag.chuaBan = "Chưa bán";
            ViewBag.Titlee = "Danh sách sản phẩm";
            return View(data.Products.Where(n => n.idProduct == id).ToPagedList(pageNumber, pageSize));
        }

    }
}
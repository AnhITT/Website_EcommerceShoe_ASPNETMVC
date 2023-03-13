using PagedList;
using System;
using System.Collections.Generic;
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
        private readonly ApplicationDbContext _context;
        public BrandController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var items = _context.Brands;
            ViewBag.Titlee = "Quản lý nhãn hàng";
            return View(items);
        }

        public ActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Brands.Add(brand);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditBrand(int id)
        {
            var item = _context.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult EditBrand(Brand model)
        {
            if (ModelState.IsValid)
            {
                _context.Brands.Attach(model);
                _context.Entry(model).Property(x => x.idBrand).IsModified = true;
                _context.Entry(model).Property(x => x.nameBrand).IsModified = true;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
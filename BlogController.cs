using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Blog
        public ActionResult Index()
        {
            var items = db.Blogs.OrderByDescending(x => x.idBlog).ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Add(Blog model)
        {
            if(ModelState.IsValid)
            {
                model.dateSubmitted = DateTime.Now;
                db.Blogs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)  
        {
            var item = db.Blogs.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Blog model)
        {
            if (ModelState.IsValid)
            {
                model.dateSubmitted = DateTime.Now;
                db.Blogs.Attach(model);
                db.Entry(model).State= System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id) 
        {
            var item = db.Blogs.Find(id);
            if(item != null)
            {
                db.Blogs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true});
            }

            return Json(new { success = false });
        }
    }
}
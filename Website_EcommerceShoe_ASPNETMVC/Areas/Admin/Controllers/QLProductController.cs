using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.ImageAssemble;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class QLProductController : Controller
    {
        // GET: Admin/Product
        private readonly ApplicationDbContext data;

        public QLProductController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult QLProduct(int? page)
        {
            ViewBag.Titlee = "Quản lý sản phẩm";
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(data.Products.ToList().ToPagedList(pageNum, pageSize));
        }
        
        public ActionResult AddProduct()
        {
            ViewBag.Titlee = "Thêm mới sản phẩm";
            ViewBag.idCAR = new SelectList(data.Categories.ToList().OrderBy(n => n.idCar), "idCar", "nameCar");
            ViewBag.idBR = new SelectList(data.Brands.ToList().OrderBy(n => n.idBrand), "idBrand", "nameBrand");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProduct(Product sp, HttpPostedFileBase fileupload)
        {
            ViewBag.idCAR = new SelectList(data.Categories.ToList().OrderBy(n => n.idCar), "idCar", "nameCar");
            ViewBag.idBR = new SelectList(data.Brands.ToList().OrderBy(n => n.idBrand), "idBrand", "nameBrand");
            if (fileupload != null && fileupload.ContentLength > 0)
            {
                //lấy tên file được tải lên từ form upload và lưu vào biến fileName.
                var fileName = Path.GetFileName(fileupload.FileName);

                //Chứa đường dẫn
                var path = Path.Combine(Server.MapPath("~/Content/Image/Product/"), fileName);

                //Lưu file
                fileupload.SaveAs(path);

                sp.UrlImgCover = fileName;
                data.Products.Add(sp);
                data.SaveChanges();
                return RedirectToAction("QLProduct");
            }
            else
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }

        }
        public ActionResult EditProduct(int id)
        {
            var product = data.Products.Find(id);
            ViewBag.Titlee = "Chỉnh sửa sản phẩm";
            ViewBag.EditCAR = new SelectList(data.Categories.ToList().OrderBy(n => n.idCar), "idCar", "nameCar", product.idCar);
            ViewBag.EditBR = new SelectList(data.Brands.ToList().OrderBy(n => n.idBrand), "idBrand", "nameBrand", product.idBrand);
            return View(product);
        }
        
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                data.Entry(product).State = EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = data.Products.Find(id);
            if (item != null)
            {

                data.Products.Remove(item);
                data.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public ActionResult AddSize(int id)
        {
            ViewBag.Titlee = "Thêm size";
            var items = data.Sizes.Where(x => x.productID == id).ToList();
            IList<Sizes> item = data.Sizes.Where(n => n.productID == id).ToList();
            ViewBag.size = item;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSize(int id, Sizes sizes)
        {
            sizes.productID = id;
            data.Sizes.Add(sizes);
            data.SaveChanges();
            return RedirectToAction("AddSize");
        }
        public ActionResult DeleteSize(int id)
        {
            var item = data.Sizes.Find(id);
            if (item != null)
            {
                data.Sizes.Remove(item);
                data.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}

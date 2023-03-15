using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private readonly ApplicationDbContext data;
        private ICollection<Category> idCar;

        public ProductController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            ViewBag.Titlee = "Quản lý sản phẩm";

            return View(data.Products.ToList());
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
        public ActionResult AddProduct(Product sp, HttpPostedFileBase fileupload, HttpPostedFileBase fileupload1)
        {
            ViewBag.idCAR = new SelectList(data.Categories.ToList().OrderBy(n => n.idCar), "idCar", "nameCar");
            ViewBag.idBR = new SelectList(data.Brands.ToList().OrderBy(n => n.idBrand), "idBrand", "nameBrand");
            sp.dateUpProduct = DateTime.Now;
            if(fileupload != null && fileupload.ContentLength > 0 && fileupload1 != null && fileupload1.ContentLength > 0)
            {
                //lấy tên file được tải lên từ form upload và lưu vào biến fileName.
                var fileName = Path.GetFileName(fileupload.FileName);
                var fileName1 = Path.GetFileName(fileupload1.FileName);
                    
                //Chứa đường dẫn
                var path = Path.Combine(Server.MapPath("~/Content/Image/Product/"), fileName);
                var path1 = Path.Combine(Server.MapPath("~/Content/Image/Product/"), fileName1);

                //Lưu file
                fileupload.SaveAs(path);
                fileupload1.SaveAs(path1);

                sp.UrlImgCover = fileName;
                sp.UrlImgCover_After = fileName1;
                data.Products.Add(sp);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            
        }
        
        public ActionResult EditProduct()
        {
            ViewBag.Titlee = "Thêm mới sản phẩm";
            ViewBag.idCAR = new SelectList(data.Categories.ToList().OrderBy(n => n.idCar), "idCar", "nameCar");
            ViewBag.idBR = new SelectList(data.Brands.ToList().OrderBy(n => n.idBrand), "idBrand", "nameBrand");
            return View();
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
    }
}

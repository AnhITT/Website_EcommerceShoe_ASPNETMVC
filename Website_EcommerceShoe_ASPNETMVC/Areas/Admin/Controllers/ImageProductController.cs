using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    public class ImageProductController : Controller
    {
        // GET: Admin/ImageProduct
        private readonly ApplicationDbContext data;

        public ImageProductController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult Index(int id, HttpPostedFileBase file)
        {
            ViewBag.Titlee = "Hình ảnh sản phẩm";
            var items = data.ImagesProducts.Where(x => x.productID == id).ToList();
            IList<ImagesProduct> item = data.ImagesProducts.Where(n => n.productID == id ).ToList();
            ViewBag.img = item;
            var sp = data.Products.Find(id);
            if (file != null && file.ContentLength > 0)
            {
                var img = new ImagesProduct();
                //lấy tên file được tải lên từ form upload và lưu vào biến fileName.
                var fileName = Path.GetFileName(file.FileName);

                //Chứa đường dẫn
                var path = Path.Combine(Server.MapPath("~/Content/Image/Product/"), fileName);

                //Lưu file
                file.SaveAs(path);
                img.urlImg = fileName;
                img.productID = id;
                data.ImagesProducts.Add(img);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var item = data.ImagesProducts.Find(id);
            if (item != null)
            {
                data.ImagesProducts.Remove(item);
                data.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
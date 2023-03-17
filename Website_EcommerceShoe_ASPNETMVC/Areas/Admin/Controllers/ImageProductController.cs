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
        public ActionResult Index(int id)
        {
            ViewBag.Titlee = "Hình ảnh sản phẩm";
            var items = data.ImagesProducts.Where(x => x.productID == id).ToList();
            return View(items);
        }
        public ActionResult AddImage(int id, HttpPostedFileBase fileupload, ImagesProduct image)
        {
            var item = data.Products.Find(id);

            if (item != null)
            {
                var fileName = Path.GetFileName(fileupload.FileName);

                //Chứa đường dẫn
                var path = Path.Combine(Server.MapPath("~/Content/Image/Product/"), fileName);

                //Lưu file
                fileupload.SaveAs(path);

                image.urlImg = fileName;
                image.productID = id;
                data.ImagesProducts.Add(image);
                data.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
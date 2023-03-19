using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;
        public ProductController()
        {
            data = new ApplicationDbContext();
        }
        // GET: Product

       
        public IList<Product> GetProductCartegory(int idDanhMuc)
        {
            IList<Product> item = data.Products.Where(n => n.idCar == idDanhMuc).ToList();
            return item;
        }
        private IList<ImagesProduct> GetProductImage(int idProduct)
        {
            IList<ImagesProduct> item = data.ImagesProducts.Where(n => n.productID == idProduct).ToList();
            return item;
        }
        private IList<Sizes> GetProductSize(int idProduct)
        {
            IList<Sizes> item = data.Sizes.Where(n => n.productID == idProduct).ToList();
            return item;
        }
        public ActionResult Index(int? page, string search)
        {
            var sp = from l in data.Products select l;

            if (!String.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                sp = sp.Where(s => s.nameProduct.ToLower().Contains(search));
            }
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(sp.ToList().ToPagedList(pageNum, pageSize));
        }

        public ActionResult Detail(int id)
        {
            Product item = data.Products.Find(id);
            IList<Product> itemsLQ = GetProductCartegory((int)item.idCar);
            IList<ImagesProduct> itemsIMG = GetProductImage(id);
            IList<Sizes> itemsSize = GetProductSize(id);
            ViewBag.ProductCartegory = itemsLQ;
            ViewBag.ImagesProduct = itemsIMG;
            ViewBag.SizeProduct = itemsSize;

            return View(item);
        }
        public ActionResult Men(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Category.nameCar == "Men").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Women(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Category.nameCar == "Women").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Kids(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Category.nameCar == "Kids").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Sport(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Category.nameCar == "Sport").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Unisex(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Category.nameCar == "Unisex").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Nike(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Brand.nameBrand == "Nike").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Adidas(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Brand.nameBrand == "Adidas").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Bitis(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Brand.nameBrand == "Biti's").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Vans(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Brand.nameBrand == "Vans").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Converse(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Brand.nameBrand == "Converse").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Jodan(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            var products = data.Products.Where(n => n.Brand.nameBrand == "Jodan").OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
    }
}
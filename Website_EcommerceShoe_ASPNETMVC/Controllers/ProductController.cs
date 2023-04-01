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
        public void CheckProductSale()
        {
            foreach (var item in data.Products.ToList())
            {
                if (item.idPSale != null)
                {
                    var KM = data.ProductSales.Where(x => x.idPS == item.idPSale).FirstOrDefault();
                    if (DateTime.Now >= KM.dateStartSale && DateTime.Now <= KM.dateEndSale && KM.quantityPS > 0)
                    {
                        if (KM.priceSalePS != null)
                        {
                            ViewData[item.nameProduct] = item.priceProduct - KM.priceSalePS;
                        }
                        else
                        {

                            ViewData[item.nameProduct] = item.priceProduct - ((item.priceProduct * KM.salePSPhanTram) / 100);
                        }
                    }
                }
            }
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
            int pageSize = 21;
            int pageNum = page ?? 1;

            CheckProductSale();
            return View(sp.Where(n => n.statusProduct == true).ToList().ToPagedList(pageNum, pageSize));
        }

        public ActionResult Detail(int id)
        {
            Product item = data.Products.Find(id);
            var checkSize = data.Sizes.Where(n => n.productID == item.idProduct).ToList();
            int count = 0;
            foreach(var check in checkSize)
            {
                if(checkSize != null && check.quantitySize > 1)
                {
                    count = 1;
                }
            }
            if(item != null)
            {
                data.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                data.Entry(item).Property(x => x.ViewCount).IsModified = true;
                data.SaveChanges();
            }
            CheckProductSale();
            ViewBag.count = count;
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
            CheckProductSale();
            var products = data.Products.Where(n => n.Category.nameCar == "Men" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Women(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Category.nameCar == "Women" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Kids(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Category.nameCar == "Kids" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        
        public ActionResult Unisex(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Category.nameCar == "Men" || n.Category.nameCar == "Women").OrderBy(n => n.idProduct);
            return View(products.Where(n => n.statusProduct == true).ToPagedList(pageNum, pageSize));
        }
        public ActionResult Nike(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Brand.nameBrand == "Nike" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Adidas(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Brand.nameBrand == "Adidas" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Bitis(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Brand.nameBrand == "Biti's" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Vans(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Brand.nameBrand == "Vans" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Converse(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Brand.nameBrand == "Converse" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Jodan(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            CheckProductSale();
            var products = data.Products.Where(n => n.Brand.nameBrand == "Jodan" && n.statusProduct == true).OrderBy(n => n.idProduct);
            return View(products.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Sale(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var sale = data.Products.ToList();
            List<Product> saleChecked = new List<Product>();
            foreach (var item in sale)
            {
                if (item.idPSale != null)
                {
                    saleChecked.Add(item);
                    var KM = data.ProductSales.Where(x => x.idPS == item.idPSale).FirstOrDefault();
                    if (DateTime.Now >= KM.dateStartSale && DateTime.Now <= KM.dateEndSale && KM.quantityPS > 0)
                    {
                        if (KM.priceSalePS != null)
                        {
                            ViewData[item.nameProduct] = item.priceProduct - KM.priceSalePS;
                        }
                        else
                        {

                            ViewData[item.nameProduct] = item.priceProduct - ((item.priceProduct * KM.salePSPhanTram) / 100);
                        }
                    }
                }
            }
            return View(saleChecked.ToPagedList(pageNumber, pageSize));
        }
    }
}
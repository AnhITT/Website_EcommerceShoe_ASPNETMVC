using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Website_EcommerceShoe_ASPNETMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private readonly ApplicationDbContext data;
        public ShoppingCartController()
        {
            data = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            Session.Timeout = 500000;
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.User = user;
            Session.Timeout = 500000;
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(Order order)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart == null)
                return RedirectToAction("ErrorCart", "ShoppingCart");
            Random rd = new Random();
            order.Code = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
            order.idCustomer = User.Identity.GetUserId();
            cart.Items.ForEach(x => order.OrderDetails.Add(new OrderDetail
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price,
                Size = x.Size
            }));
            order.TotalAmount = cart.Items.Sum(x => (x.Price * x.Quantity));
            order.DateOrder = DateTime.Now;
            data.Orders.Add(order);
            data.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("CheckOutSuccess");

        }
        public ActionResult CheckOutSuccess(Order order)
        {
            return View(order);
        }

            public ActionResult Partial_Item_Checkout()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }

        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Partial_CheckOut()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddToCart(int id, string size ,int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            var db = new ApplicationDbContext();
            var checkProduct = db.Products.FirstOrDefault(x => x.idProduct == id);
            var checkSize = db.Sizes.FirstOrDefault(x => x.nameSize == size);

            if (checkProduct != null && checkSize != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.idProduct,
                    ProductName = checkProduct.nameProduct,
                    Quantity = quantity,
                    Size = size
                };
                if (checkProduct.IdSale != null)
                {
                    var KM = data.ProductSales.Where(x => x.idPS == checkProduct.idPSale).FirstOrDefault();
                    if (DateTime.Now >= KM.dateStartSale && DateTime.Now <= KM.dateEndSale && KM.quantityPS > 0)
                    {
                        if (KM.priceSalePS != null)
                        {
                            item.Price = (decimal)(checkProduct.priceProduct - KM.priceSalePS);
                            item.TotalPrice = item.Quantity * item.Price;
                        }
                        else
                        {
                            item.Price = (decimal)(checkProduct.priceProduct - ((checkProduct.priceProduct * KM.salePSPhanTram) / 100));
                            item.TotalPrice = item.Quantity * item.Price;
                        }
                    }
                }
                else
                {
                    item.Price = checkProduct.priceProduct;
                    item.TotalPrice = item.Quantity * item.Price;
                }
                item.ProductImg = checkProduct.UrlImgCover;
                cart.AddToCart(item, size, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Product added to cart successfully!", code = 1, Count = cart.Items.Count };
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }

       
        public ActionResult ErrorCart()
        {
            return View();
        }
    }
}

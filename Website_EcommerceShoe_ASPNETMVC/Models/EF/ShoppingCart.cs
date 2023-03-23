using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, string size, int Quantity)
        {
            // Kiểm tra sản phẩm có tồn tại trong giỏ hàng hay không
            var checkExits = Items.FirstOrDefault(x => x.ProductId == item.ProductId);
            var checkSize = Items.FirstOrDefault(x => x.Size == size);

            if (checkExits != null && checkSize != null)
            {
                //Nếu có thì sl +
                checkExits.Quantity += Quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                //Nếu chưa thì add vào giỏ hàng
                Items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.TotalPrice);
        }
        public int GetTotalQuantity()
        {
            return Items.Sum(x => x.Quantity);
        }
        public void ClearCart()
        {
            Items.Clear();
        }

    }

    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
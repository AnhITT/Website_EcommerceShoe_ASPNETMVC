using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_EcommerceShoe_ASPNETMVC.Models.EF
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string idCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

        public DateTime DateOrder { get; set; }

        public decimal TotalAmount { get; set; }
        public int TypePayment { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
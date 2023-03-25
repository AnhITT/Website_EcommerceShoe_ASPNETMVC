using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_EcommerceShoe_ASPNETMVC.Models;
using Website_EcommerceShoe_ASPNETMVC.Models.EF;

namespace Website_EcommerceShoe_ASPNETMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QLOrderController : Controller
    {
        private readonly ApplicationDbContext data;

        public QLOrderController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult QLOrder(int? page)
        {
            ViewBag.Titlee = "Quản lý đơn hàng";
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(data.Orders.ToList().ToPagedList(pageNum, pageSize));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = data.Orders.Find(id);
            if (item != null)
            {

                data.Orders.Remove(item);
                data.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public ActionResult Detail(int id)
        {
            ViewBag.Titlee = "Chi tiết hoá đơn";
            IList<OrderDetail> item = data.OrderDetails.Where(n => n.OrderId == id).ToList();
            return View(item);
        }
        public List<Order> GetOrder()
        {
            return data.Orders.ToList();
        }
        
        public void ExportExcel()
        {

            var list = GetOrder();
            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet Sheet = ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Mã hoá đơn";
            Sheet.Cells["B1"].Value = "Tên khách hàng";
            Sheet.Cells["C1"].Value = "Địa chỉ";
            Sheet.Cells["D1"].Value = "Số điện thoại";
            Sheet.Cells["E1"].Value = "Email";
            Sheet.Cells["F1"].Value = "Thời gian";
            Sheet.Cells["G1"].Value = "Mã sản phẩm";
            Sheet.Cells["H1"].Value = "Giá";
            Sheet.Cells["I1"].Value = "Size";
            Sheet.Cells["J1"].Value = "Số lượng";
            Sheet.Cells["K1"].Value = "Tổng tiền";


            int row = 2;// dòng bắt đầu ghi dữ liệu
            foreach (var item in list)
            {
                var ct = data.OrderDetails.Where(n => n.OrderId == item.Id);
                if(ct.Any() || ct != null)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Id;
                    Sheet.Cells[string.Format("B{0}", row)].Value = item.NameCustomer;
                    Sheet.Cells[string.Format("C{0}", row)].Value = item.Address;
                    Sheet.Cells[string.Format("D{0}", row)].Value = item.Phone;
                    Sheet.Cells[string.Format("E{0}", row)].Value = item.Email;
                    Sheet.Cells[string.Format("F{0}", row)].Value = item.DateOrder.ToString();

                    foreach (var item1 in ct)
                    {
                        Sheet.Cells[string.Format("G{0}", row)].Value = item1.ProductId;
                        Sheet.Cells[string.Format("H{0}", row)].Value = item1.Price;
                        Sheet.Cells[string.Format("I{0}", row)].Value = item1.Size;
                        Sheet.Cells[string.Format("J{0}", row)].Value = item1.Quantity;
                        row++;
                    }
                    Sheet.Cells[string.Format("K{0}", row)].Value = item.TotalAmount;
                    row++;
                }
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "Report.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();
        }
    }
}
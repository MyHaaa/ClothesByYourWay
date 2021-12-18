using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Models;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Controllers
{
    public class ShoppingCartController : Controller
    {
        ClothesBYWDbContext db = new ClothesBYWDbContext();
        // GET: ShoppingCart
        // GET: ShoppingCart
        public ActionResult Showcart()
        {
            if (Session["Models.GioHang"] == null)
                return View("EmptyCart");
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            return View(gh);
        }
        //Tao moi gio hang
        public Models.GioHang GetGioHang()
        {
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            if (gh == null || Session["Models.GioHang"] == null)
            {
                gh = new Models.GioHang();
                Session["Models.GioHang"] = gh;
            }
            return gh;
        }

        //them sp vao gio hang
        public ActionResult addtocart(string id)
        {
            var pro = db.ProductLines.SingleOrDefault(s => s.ProductLineID == id);
            if (pro != null)
            {
                GetGioHang().ThemSPVaoGioHang(pro);
            }

            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //update gio hang
        public ActionResult Update_Cart_Qua(FormCollection form)
        {
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            string id = (form["IDPro"]);
            ProductLine sp = db.ProductLines.Find(id);
            int qua = int.Parse(form["QualityPro"]);
            cart.update_sp(id, qua);
            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //xoa gio hang
        public ActionResult Remove(string id)
        {
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            cart.XoaSP(id);
            return RedirectToAction("Showcart", "ShoppingCart");

        }
        public PartialViewResult BagCart()
        {
            int total_quality = 0;
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            if (cart != null)
            {
                total_quality = cart.TongSP();

            }
            ViewBag.QuantityCart = total_quality;
            return PartialView("BagCart");
        }
        public ActionResult XoaALL()
        {
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            cart.ClearCart();
            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //public ActionResult CheckOut(FormCollection form)
        //{
        //    try
        //    {
        //        Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
        //        // Khach hang moi
        //        /* IDEA
        //         * Tạo 1 hàm, trong đó đầu vào là 1 chuỗi cũ (gọi là chuỗi x)
        //         * (VD: KH0001 -> Lấy từ db.TAIKHOAN.FindLast)
        //         * x.Subtring (0,2) -> chuỗi tĩnh
        //         * convert.ToInt(x.substring(2,last) -> số i cũ
        //         * Tăng i++
        //         * Convert i mới sang chuỗi 4 ký tự
        //         * kết quả= chuỗi tỉnh + chuỗi i
        //         */
        //        Customer kh = new Customer();
        //        kh.CustomerCatergoryID = this.GuidId();//
        //        kh.DateOfBirth = DateTime.Now;

        //        kh.Name = form["TenKhachHang"];
        //        kh.Phone = form["DienThoaiKhach"];
        //        kh.Email = form["Email"];
        //        Order order = new Order();
        //        order.CustomerID = kh.CustomerID;
        //        db.Customers.Add(kh);

        //        order.OrderID = this.GuidId();//
        //        order.AddressShip = form["DiaChiKhachHang"];
        //        order.DeliveryDatetime = DateTime.Now;
        //        db.Orders.Add(order);

        //        foreach (var item in cart.Items)
        //        {

        //            OrderDetail order_detail = new OrderDetail();
        //            //order_detail.ID = i.ToString();
        //            order_detail.OrderID = order.OrderID;
        //            order_detail.ProductID = item.sp.ProductID;
        //            order_detail.OrderDetailID = this.GuidId();//
        //            order_detail.Product.Prices = (float)item.sp.Prices.First().RetailPrice;
        //            order_detail.QuantitySold = item.SoLuong;
        //            db.OrderDetails.Add(order_detail);
        //            foreach (var p in db.Products.Where(s => s.ProductID == order_detail.ProductID))
        //            {
        //                var update_quan_pro = p.QuantityInStock - item.SoLuong;
        //                p.QuantityInStock = update_quan_pro;

        //            }

        //        }

        //        db.SaveChanges();
        //        cart.ClearCart();

        //        return RedirectToAction("Check_out_success", "ShoppingCart");
        //    }
        //    catch (Exception e)
        //    {
        //        return Content("Error checkout. Please check information customer...");
        //    }


        //}
        //public ActionResult FormTTKH()
        //{
        //    return View();
        //}
        public ActionResult Check_out_success()
        {
            return View();
        }
    }
}

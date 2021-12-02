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
            var pro = db.Products.SingleOrDefault(s => s.ProductID == id);
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
            Product sp = db.Products.Find(id);
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
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Areas.Administrator.Models;
using ClothesBYW.Common;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class OrdersController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // GET: Administrator/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Voucher).ToList();
            return View(orders.ToList());
        }

        // GET: Administrator/Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            var orderItems = db.OrderDetails.Where(x => x.OrderID == order.OrderID).ToList();
            var shipOrder = db.ShipperOrders.Where(x => x.OrderID == id).OrderByDescending(x => x.ShipperOrderID).Skip(1).ToList();
            var shipOrderdemo = db.ShipperOrders.Where(x => x.OrderID == id).OrderByDescending(x => x.ShipperOrderID).ToList();
            int count = shipOrder.Count();

            OrderDetailsModel model = new OrderDetailsModel();
            model.order = order;
            model.orderDetails = orderItems;
            model.shipperOrder = shipOrderdemo.Take(1).ToList();
            model.shipperOrders = shipOrder;

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeStatus(string id)
        {
            var order = db.Orders.Find(id);
            ChangStatusOrder model = new ChangStatusOrder();
            model.OrderID = order.OrderID;
            model.StatusID = order.Status;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ChangeStatus(ChangStatusOrder model)
        {
            var order = db.Orders.Find(model.OrderID);
            //string username = Session["Username"].ToString();

            order.Status = model.StatusID;
            //purchaseOrderRepository.ModifiedInfor(po.PurchaseOrderID, username, DateTime.Now);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = order.OrderID });
        }

        [HttpGet]
        public ActionResult DeliveryIden(string id)
        {
            var order = db.Orders.Find(id);
            var orderSession = new OrderModel();
            orderSession.OrderID = order.OrderID;

            Session.Add(CC.ORDER_ID_SESSION, orderSession);
            Session["OrderID"] = orderSession.OrderID;

            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name");
            return PartialView();
        }

        [HttpPost]
        public ActionResult DeliveryIden(ShipperOrder shipperOrder)
        {
            if (ModelState.IsValid)
            {
                shipperOrder.OrderID = Session["OrderID"].ToString();

                db.ShipperOrders.Add(shipperOrder);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = shipperOrder.OrderID });

            }

            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", shipperOrder.ShipperID);
            return PartialView(shipperOrder);
           

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

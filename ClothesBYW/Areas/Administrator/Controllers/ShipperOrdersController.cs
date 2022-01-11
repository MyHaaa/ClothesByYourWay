using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class ShipperOrdersController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // GET: Administrator/ShipperOrders
        public ActionResult Index()
        {
            var shipperOrders = db.ShipperOrders.Include(s => s.Order).Include(s => s.Shipper);
            return View(shipperOrders.ToList());
        }

        // GET: Administrator/ShipperOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipperOrder shipperOrder = db.ShipperOrders.Find(id);
            if (shipperOrder == null)
            {
                return HttpNotFound();
            }
            return View(shipperOrder);
        }

        // GET: Administrator/ShipperOrders/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name");
            return View();
        }

        // POST: Administrator/ShipperOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperOrderID,OrderID,EmployeeID,ShipperID,DeliveryDatetime,DeliveryNote")] ShipperOrder shipperOrder)
        {
            if (ModelState.IsValid)
            {
                db.ShipperOrders.Add(shipperOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", shipperOrder.OrderID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", shipperOrder.ShipperID);
            return View(shipperOrder);
        }

        // GET: Administrator/ShipperOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipperOrder shipperOrder = db.ShipperOrders.Find(id);
            if (shipperOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", shipperOrder.OrderID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", shipperOrder.ShipperID);
            return View(shipperOrder);
        }

        // POST: Administrator/ShipperOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperOrderID,OrderID,EmployeeID,ShipperID,DeliveryDatetime,DeliveryNote")] ShipperOrder shipperOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipperOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", shipperOrder.OrderID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", shipperOrder.ShipperID);
            return View(shipperOrder);
        }

        // GET: Administrator/ShipperOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipperOrder shipperOrder = db.ShipperOrders.Find(id);
            if (shipperOrder == null)
            {
                return HttpNotFound();
            }
            return View(shipperOrder);
        }

        // POST: Administrator/ShipperOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipperOrder shipperOrder = db.ShipperOrders.Find(id);
            db.ShipperOrders.Remove(shipperOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
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

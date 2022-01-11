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
    public class ShippersController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // GET: Administrator/Shippers
        public ActionResult Index()
        {
            var shippers = db.Shippers.Include(s => s.DeliveryUni);
            return View(shippers.ToList());
        }

        // GET: Administrator/Shippers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // GET: Administrator/Shippers/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryUnitID = new SelectList(db.DeliveryUnis, "DeliveryUnitID", "Name");
            return View();
        }

        // POST: Administrator/Shippers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,Name,Email,Address,Phone,DeliveryUnitID")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                var rand = new Random();
                var uid = rand.Next(100000, 1000000);

                shipper.ShipperID = uid.ToString();
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryUnitID = new SelectList(db.DeliveryUnis, "DeliveryUnitID", "Name", shipper.DeliveryUnitID);
            return View(shipper);
        }



        // GET: Administrator/Shippers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryUnitID = new SelectList(db.DeliveryUnis, "DeliveryUnitID", "Name", shipper.DeliveryUnitID);
            return View(shipper);
        }

        // POST: Administrator/Shippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID,Name,Email,Address,Phone,DeliveryUnitID")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryUnitID = new SelectList(db.DeliveryUnis, "DeliveryUnitID", "Name", shipper.DeliveryUnitID);
            return View(shipper);
        }

        // GET: Administrator/Shippers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // POST: Administrator/Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Shipper shipper = db.Shippers.Find(id);
            db.Shippers.Remove(shipper);
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

using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class DashboardController : BaseController
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // GET: Administrator/Dashboard
        public ActionResult Index()
        {
            int countCustomer = db.Customers.Count();
            int countOrder = db.Orders.Count();
            int countPurchase = db.PurchaseOrders.Count();
            int countProduct = db.Products.Count();

            

            TempData["Customer"] = countCustomer;
            TempData["Order"] = countOrder;
            TempData["Purchase"] = countPurchase;
            TempData["Product"] = countProduct;

            return View();
        }

        // GET: Administrator/Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrator/Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrator/Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

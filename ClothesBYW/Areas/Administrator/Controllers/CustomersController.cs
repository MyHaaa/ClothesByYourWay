using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Areas.Administrator.Models;
using ClothesBYW.Common;
using ClothesBYW.Common.EmailService;
using Common;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class CustomersController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();
        public ActionResult Index()
        {
            var customers = db.Customers.Include(e => e.CustomerCategory);
            return View(customers.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            var orderList = db.Orders.Where(x => x.CustomerID == id).ToList();

            CustomerDetails customerDetails = new CustomerDetails();
            customerDetails.Customer = customer;
            customerDetails.Orders = orderList;

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customerDetails);
        }

        [HttpPost]
        public JsonResult ChangeStatus(string id)
        {
            var result = new CustomersDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
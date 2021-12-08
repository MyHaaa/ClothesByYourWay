using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class ProfileController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();
        // GET: Administrator/Profile
        public ActionResult Index()
        {
            string username = Session["Username"].ToString();
            return View(db.Employees.SingleOrDefault(x => x.Username == username));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            string username = Session["Username"].ToString();
            return View(db.Employees.SingleOrDefault(x => x.Username == username));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            string username = Session["Username"].ToString();

            if (ModelState.IsValid)
            {
                //db.Entry(customer).State = EntityState.Modified;
                var cus = db.Employees.SingleOrDefault(x => x.Username == username);

                cus.Name = cus.Name;
                cus.Username = employee.Username;
                cus.Password = cus.Password;
                cus.Address = employee.Address;
                cus.Email = cus.Email;
                cus.Phone = employee.Phone;
                cus.DateOfBirth = cus.DateOfBirth;
                cus.CitizenID = cus.CitizenID;

                db.Entry(cus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
            return View(employee);
        }
    }
}
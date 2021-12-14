using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Controllers
{
    public class CustomersController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        [HttpGet]
       public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Exclude = " ActivationCode")] Customer customer)
        {
            /*
            bool status = false;
            string message = "";
            */

            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(customer.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email đã tồn tại trong hệ thống");
                    return View(customer);
                }
                else
                {
                    string empNum = db.Customers.Count().ToString();
                    customer.CreateDated = DateTime.Now;
                    customer.CustomerID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + empNum;

                    customer.ActivationCode = Guid.NewGuid();

                    db.Customers.Add(customer);
                    db.SaveChanges();

                    SendVerificationLinkEmail(customer.Email, customer.ActivationCode.ToString());
                }
            }
            else
            {
                //message = " Yêu cầu không hợp lệ";
            }

            return View(customer);
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }




        [NonAction]
        public bool IsEmailExist(string email)
        {
            var emp = db.Customers.Where(e => e.Email == email).FirstOrDefault();
            return emp != null;
        }
        
        [NonAction]
        public void SendVerificationLinkEmail(string email, string acticationCode)
        {

        }
    }
}
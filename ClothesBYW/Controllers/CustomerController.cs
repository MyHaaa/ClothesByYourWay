using ClothesBYW.Models.Customer;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View(UserLoginSingleton.GetInstance().GetAccount());
        }
        public ActionResult Logout()
        {
            UserLoginSingleton.GetInstance().Logout();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult UpdateAccount(Customer newInfo)
        {
            return RedirectToAction("Index", "Customer");
        }
    }
}
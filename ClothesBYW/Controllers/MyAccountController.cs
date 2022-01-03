using ClothesBYW.Models.Customer;
using Models.Dao.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            var user = UserLoginSingleton.GetInstance().GetAccount();
            var dao = new AccountDao();
            user.Orders = dao.GetOrders(user.ID);
            return View(user);
        }
        public ActionResult Logout()
        {
            UserLoginSingleton.GetInstance().Logout();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult UpdateAccount(string name, string mobile, string email, string address)
        {
            var dao = new AccountDao();
            var newCus = dao.UpdateInfo(UserLoginSingleton.GetInstance().GetAccount().ID, name, mobile, email, address);
            UserLoginSingleton.Init(newCus.CustomerID, newCus.Name, newCus.Username, newCus.DateOfBirth, newCus.Phone, newCus.Address, newCus.Email);
            return RedirectToAction("Index", "MyAccount");
        }

    }
}
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
        public ActionResult Index(string currentOrder, string noti)
        {
            var user = UserLoginSingleton.GetInstance().GetAccount();
            var dao = new AccountDao();
            user.Orders = dao.GetOrders(user.ID);
            if(currentOrder != "")
            {
                user.CurrentOrder = currentOrder;
            }
            ViewBag.Error = noti;
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
        [HttpPost]
        public ActionResult ChangePassword(string oldPass, string newPass, string confirmPass)
        {
            if(newPass != confirmPass)
            {
                return RedirectToAction("Index", "MyAccount",new { noti= "Confirm password was not correct!" });
            }
            var dao = new AccountDao();
            if (!dao.ChangePassword(UserLoginSingleton.GetInstance().GetAccount().ID, oldPass, newPass))
            {
                return RedirectToAction("Index", "MyAccount", new { noti = "Password was not correct!" });
            }
            return RedirectToAction("Logout", "MyAccount");
        }
    }
}
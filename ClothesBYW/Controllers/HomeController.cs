using ClothesBYW.Models;
using ClothesBYW.Models.Customer;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesBYW.Controllers
{
    public class HomeController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid) //Nếu vượt qua kiểm tra form rỗng hay không
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.Email, model.Password);// biến kết quả
                if (result == 1)
                {
                    var user = dao.GetCustomer(model.Email);

                    UserLoginSingleton.Init(user.CustomerID, user.Name, user.Username, user.DateOfBirth, user.Phone, user.Address, user.Email);
                    return RedirectToAction("Index","Home");
                }
                else if (result == 0)
                {
                    ViewBag.Error = "Tài khoản không tồn tại";
                }
                else if (result == -1)
                {
                    ViewBag.Error = "Tài khoản đang bị khóa";
                }
                else if (result == -2)
                {
                    ViewBag.Error = "Mật khẩu không hợp lệ";
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công!";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "Xác nhận mật khẩu không đúng";
            }
            else
            {
                var dao = new CustomerDao();
                var result = dao.Regist(model.Username, model.Email, model.Phone, model.Password);// biến kết quả
                if (result == 1)
                {
                    ViewBag.Success = "Đăng ký thành công";
                }
                else if (result == -1)
                {
                    ViewBag.Error = "Email đã có trong hệ thống";
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công!";
                }
            }
            return View();
        }
    }
}
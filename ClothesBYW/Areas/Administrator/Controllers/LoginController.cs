
using Models.Dao;

using ClothesBYW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Models.EF;
using ClothesBYW.Areas.Administrator.Models;
using System.Threading.Tasks;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        public string USER_SESSION { get; private set; }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid) //Nếu vượt qua kiểm tra form rỗng hay không
            {
                var dao = new EmployeeDao();
                var result = dao.Login(model.Username, model.Password);// biến kết quả
                if (result == 1)
                {
                    var user = dao.GetByID(model.Username);
                    var userSession = new EmployeeLogin();
                    userSession.Username = user.Username;
                    userSession.EmployeeID = user.EmployeeID;
                    userSession.UserGroupID = user.UserGroupID;
                    var listCredentials = dao.GetListCredential(model.Username);

                    Session.Add(CC.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CC.USER_SESSION, userSession);
                    Session["Username"] = userSession.Username;
                    Session["EmployeeID"] = userSession.EmployeeID;
                    Session["UserGroupID"] = userSession.UserGroupID;


                    return RedirectToAction("Index", "Dashboard");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không hợp lệ");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn chưa xác thực qua Email");
                }

            }
            return View("Index");
        }

        

    }
}
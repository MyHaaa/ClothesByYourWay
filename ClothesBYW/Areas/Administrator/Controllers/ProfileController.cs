using ClothesBYW.Areas.Administrator.Models;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

        [HttpPost]
        public ActionResult UpdateAva(PictureUpdate obj)
        {
            string username = Session["Username"].ToString();
            var file = obj.Picture;
            Employee emp = db.Employees.SingleOrDefault(x => x.Username == username);
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string id_and_extension = username + extension;
                string imgUrl = "/Areas/Administrator/Data/ProfileEmp" + id_and_extension;
                emp.Image = imgUrl;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();

                var path = Server.MapPath("/Areas/Administrator/Data/ProfileEmp");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if ((System.IO.File.Exists(path + id_and_extension)))
                {
                    System.IO.File.Delete(path + id_and_extension);
                }
                file.SaveAs((path + id_and_extension));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            string username = Session["Username"].ToString();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string username = Session["Username"].ToString();
            Employee emp = db.Employees.SingleOrDefault(x => x.Username == username);
            if (emp.Password == model.OldPassword)
            {
                emp.Password = model.NewPassword;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Mật khẩu cũ", "Mật khẩu cũ không trùng khớp");
            }
            return View();
        }
    }
}
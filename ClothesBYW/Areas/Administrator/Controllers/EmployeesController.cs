using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Common;
using ClothesBYW.Common.EmailService;
using Common;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class EmployeesController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // GET: Administrator/Employees
        [HasCredentialAtrribute(RoleID = "VIEW_EMPLOYEE")]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.UserGroup);
            return View(employees.ToList());
        }

        // GET: Administrator/Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Administrator/Employees/Create
        public ActionResult Create()
        {
            ViewBag.UserGroupID = new SelectList(db.UserGroups, "UserGroupID", "Name");
            return View();
        }

        // POST: Administrator/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,Username,Password,DateOfBirth,CitizenID,UserGroupID,Phone,Address,Email,CreateDated,Status")] Employee employee)
        {
            bool Status = false;
            string message = " ";

            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(employee.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email đã tồn tại trong hệ thống");
                    return View(employee);
                }
                else
                {
                    var emp = new Employee();
                    string empNum = db.Employees.Count().ToString();                   
                    emp.CreateDated = DateTime.Now;
                    emp.EmployeeID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + empNum;
                    emp.Password = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                    emp.Username = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + empNum;
                    emp.Name = employee.Name;
                    emp.Address = employee.Address;
                    emp.CitizenID = employee.CitizenID;
                    emp.DateOfBirth = employee.DateOfBirth;
                    emp.Phone = employee.Phone;
                    emp.Email = employee.Email;
                    emp.IsEmailVerified = false;
                    emp.UserGroupID = employee.UserGroupID;
                    emp.Status = true;
                    emp.Image = "/Areas/Administrator/Data/NewUserAva.png";

                    emp.ActivationCode = Guid.NewGuid();

                    db.Employees.Add(emp);
                    db.SaveChanges();

                    SendVerificationLinkEmail(emp.Email, emp.ActivationCode.ToString());
                    message = "Đăng ký tài khoản thành công. Link kích hoạt tài khoản" +
                        "đã được gửi vào " + emp.Email;
                    Status = true;
                }
            }
            else
            {
                message = " Yêu cầu không hợp lệ";
            }
            ViewBag.Status = Status;
            ViewBag.message = message;
            TempData["Message"] = message;
            ViewBag.UserGroupID = new SelectList(db.UserGroups, "UserGroupID", "Name", employee.UserGroupID);
            return View(employee);
        }

        // GET: Administrator/Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserGroupID = new SelectList(db.UserGroups, "UserGroupID", "Name", employee.UserGroupID);
            return View(employee);
        }

        // POST: Administrator/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,Username,Password,DateOfBirth,CitizenID,UserGroupID,Phone,Address,Email,CreateDated,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserGroupID = new SelectList(db.UserGroups, "UserGroupID", "Name", employee.UserGroupID);
            return View(employee);
        }

        // GET: Administrator/Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Administrator/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            db.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                            // Confirm password does not match issue on save changes
            var emp = db.Employees.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
            if (emp != null)
            {
                emp.IsEmailVerified = true;
                db.SaveChanges();
                Status = true;
            }
            else
            {
                ViewBag.message = "Yêu cầu hợp lệ";
            }
            ViewBag.Status = Status;
            return RedirectToAction("Login", "Login", new { area = "Administrator" });
        }

        [HttpPost]
        public JsonResult ChangeStatus(string id)
        {
            var result = new EmployeeDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [NonAction]
        public bool IsEmailExist(string email)
        {
            var emp = db.Employees.Where(e => e.Email == email).FirstOrDefault();
            return emp != null;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string email, string acticationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Employees/" + emailFor + "/" + acticationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("clothingbyw@gmail.com", "Clothing By Your Way");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "efqpdrmrzytmwywi";

            string subject = "";
            string body = "";

            if (emailFor == "VerifyAccount")
            {
                subject = "Tài khoản của bạn đã đăng ký thành công!";
                body = "<br/><br/> Chúng tôi vui mừng thông báo cho bạn biết rằng tài khoản Clothing BYW của bạn đã được đăng ký thành công" +
                   " Xin hãy click vào link dưới đây để xác thực tài khoản " +
                   "<br/><br/><a href='" + link + "'>" + link + "</a>";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "<br/><br/> Chúng tôi đã nhận được lời yêu cầu về việc reset lại mật khẩu tài khoản của bạn" +
                   " Xin hãy click vào link dưới đây để xác nhận bạn là chủ tài khoản này và mật khẩu mới là mã nhân viên của bạn" +
                   "<br/><br/><a href='" + link + "'>" + link + "</a>";
            }

            //var sendEmail = new EmailService();
            //sendEmail.Send(fromEmail.Address, toEmail.ToString(), subject, body);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }


        //Quên pass
        public ActionResult ForgotPass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPass(string Email)
        {
            string message = "";
            bool status = false;

            var account = db.Employees.Where(a => a.Email == Email).FirstOrDefault();
            if (account != null)
            {
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                account.ResetPasswordCode = resetCode;

                db.SaveChanges();
                message = "Link reset mật khẩu đã được gửi vào email bạn vừa nhập";
            }
            else
            {
                message = "Xin lỗi, Email bạn vừa nhập không tồn tại trong hệ thống";
            }
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword(string id)
        {
            var emp = db.Employees.Where(e => e.ResetPasswordCode == id).FirstOrDefault();
            if (emp != null)
            {
                emp.Password = emp.EmployeeID;
                emp.ResetPasswordCode = "";
                db.SaveChanges();
                return RedirectToAction("Login", "Login", new { area = "Administrator" });
            }
            else
            {
                return HttpNotFound();
            }
        }

        //[HttpPost]
        //public ActionResult ResetPassword(ResetPasswordModel model)
        //{
        //    var message = "";
        //    if (ModelState.IsValid)
        //    {
        //        var emp = db.Employees.Where(e => e.ResetPasswordCode == model.ResetCode).FirstOrDefault();
        //        if(User!= null)
        //        {
        //            emp.Password = model.NewPassword;
        //            emp.ResetPasswordCode = "";
        //            db.SaveChanges();
        //            message = "Mật khẩu mới đã được cập nhật thành công";
        //        }
        //    }
        //    else
        //    {
        //        message = "Đã xảy ra lôi";
        //    }
        //    ViewBag.Message = message;
        //    return View(model);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

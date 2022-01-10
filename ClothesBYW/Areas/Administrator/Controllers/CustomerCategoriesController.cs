using ClothesBYW.Commands;
using ClothesBYW.Common;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class CustomerCategoriesController : Controller
    {
        private CommandManager commandManager = null;
        private CustomerCategoryDao dao = new CustomerCategoryDao();

        // GET: Administrator/CustomerCategorys
        public CustomerCategoriesController()
        {
            this.commandManager = new CommandManager();
        }

        public CustomerCategoriesController(CommandManager commandManager)
        {
            this.commandManager = commandManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllDepartment());
        }

        IEnumerable<CustomerCategory> GetAllDepartment()
        {
            using (ClothesBYWDbContext db = new ClothesBYWDbContext())
            {
                return db.CustomerCategories.ToList<CustomerCategory>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            CustomerCategory emp = new CustomerCategory();
            if (id != 0)
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    emp = db.CustomerCategories.Where(x => x.CustomerCategoryID == id).FirstOrDefault<CustomerCategory>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(CustomerCategory emp)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    if (emp.CustomerCategoryID == 0)
                    {
                        commandManager.IVoke(new AddCustomerCategoryCommand(emp, dao));
                    }
                    else
                    {
                        commandManager.IVoke(new EditCustomerCategoryCommand(emp, dao));
                        //db.Entry(emp).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllDepartment()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Undo()
        {
            commandManager.Undo();

            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ClothesBYWDbContext db = new ClothesBYWDbContext())
                {
                    commandManager.IVoke(new DeleteCustomerCategoryCommand(id, dao));
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllDepartment()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
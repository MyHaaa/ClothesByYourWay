using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class FeedbacksController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        // GET: Administrator/Feedbacks
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks.Include(f => f.Customer).Include(f => f.Product);
            return View(feedbacks.ToList());
        }

        // GET: Administrator/Feedbacks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return PartialView(feedback);
        }     

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new FeedbackDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
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

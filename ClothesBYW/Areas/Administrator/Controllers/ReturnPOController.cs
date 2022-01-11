using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ClothesBYW.Areas.Administrator.Models;
using ClothesBYW.Base;
using ClothesBYW.Common;
using ClothesBYW.Repos.Implementation;
using Common;
using Models.EF;
using Rotativa;

namespace ClothesBYW.Areas.Administrator.Controllers
{
    public class ReturnPOController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();

        private Repository<PurchaseOrder> repository = null;
        private PurchaseOrderRepository purchaseOrderRepository = null;
        private ProductRepository productRepository = null;
        private ProductLineRepository productLineRepository = null;
        public ReturnPOController()
        {
            this.repository = new Repository<PurchaseOrder>();

            this.purchaseOrderRepository = new PurchaseOrderRepository();
            this.productRepository = new ProductRepository();
            this.productLineRepository = new ProductLineRepository();
        }
        public ReturnPOController(Repository<PurchaseOrder> repository, PurchaseOrderRepository purchaseOrderRepository, ProductRepository productRepository, ProductLineRepository productLineRepository)
        {
            this.repository = repository;
            this.purchaseOrderRepository = purchaseOrderRepository;
            this.productRepository = productRepository;
            this.productLineRepository = productLineRepository;
        }

        public ActionResult Index()
        {
            int count = db.PurchaseOrders.Where(x => x.Status == 2 || x.Status == 3 || x.Status == 4 || x.Status == 7 || x.Status == 6).Count();
            TempData["POCount"] = count;

            return View(db.PurchaseOrders.Where(x=> x.Status == 2 || x. Status == 3 || x.Status == 4 || x.Status == 7 || x.Status == 6).ToList());
        }

        [HttpGet]
        public ActionResult ReturnPODetails(string id)
        {
            //string username = Session["Username"].ToString();

            var po = purchaseOrderRepository.GetById(id);
            var poDetail = db.PurchaseOrderDetails.Where(d => d.PurchaseOrderID == id).ToList();
            var supplier = db.Suppliers.Find(po.SupplierID);

            var poSession = new PurchaseOrderModel();
            poSession.PurchaseOrderID = po.PurchaseOrderID;
            poSession.SupplierID = po.SupplierID;

            Session.Add(CC.PURCHASE_ORDER_SESSION, poSession);
            Session["PurchaseOrderID"] = poSession.PurchaseOrderID;
            Session["SupplierID"] = poSession.SupplierID;

            PurchaseOrderDetails detail = new PurchaseOrderDetails();
            detail.PurchaseOrder = po;
            detail.POProduct = poDetail;
            detail.Supplier = supplier;

            return View(detail);
        }

        [HttpGet]
        public ActionResult ChangeStatus(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ChangeStatus(ChangeStatusPO model)
        {
            string poID = Session["PurchaseOrderID"].ToString();
            var po = purchaseOrderRepository.GetById(poID);
            //string username = Session["Username"].ToString();

            purchaseOrderRepository.ChangeStatus(po.PurchaseOrderID, model.StatusID);
            //purchaseOrderRepository.ModifiedInfor(po.PurchaseOrderID, username, DateTime.Now);
            purchaseOrderRepository.Save();

            return RedirectToAction("ReturnPODetails", new { id = poID });
        }

        [HttpGet]
        public ActionResult ReceivedItems(string id)
        {
            var pot = db.PurchaseOrderDetails.Where(x => x.PurchaseOrderDetailID == id).SingleOrDefault();

            return PartialView(pot);
        }

        [HttpPost]
        public ActionResult ReceivedItems(PurchaseOrderDetail pot)
        {
            string poID = Session["PurchaseOrderID"].ToString();

            var line = db.PurchaseOrderDetails.Where(x => x.PurchaseOrderDetailID == pot.PurchaseOrderDetailID).SingleOrDefault();
            line.QuantityReceived = pot.QuantityReceived;
            line.PricePurchase = pot.PricePurchase;
            if (line.QuantityReceived == line.QuantityPurchase)
                line.Status = 1; // đã nhận đủ hàng
            else if (line.QuantityReceived < line.QuantityPurchase)
                line.Status = 2; // chưa nhận đủ hàng
            db.SaveChanges();

            return RedirectToAction("ReturnPODetails", new { id = poID });
        }

        [HttpGet]
        public ActionResult ApproveReturnPO(string id)
        {
            var po = purchaseOrderRepository.GetById(id);
            PurchaseOrderIDModel model = new PurchaseOrderIDModel();
            model.PurchaseOrderID = po.PurchaseOrderID;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ApproveReturnPO(PurchaseOrderIDModel model)
        {
            string poID = Session["PurchaseOrderID"].ToString();

            var poList = db.PurchaseOrderDetails.Where(x => x.PurchaseOrderID == poID).ToList();
            bool check = true;
            decimal? total = 0;

            foreach(var item in poList)
            {
                if (item.Status == 2)
                {
                    check = false;
                    break;
                }
            }
            foreach(var item in poList)
            {
                total = item.PricePurchase * item.QuantityReceived;
                ChangeQuanInStock(item.ProductLineID, (int)item.QuantityReceived);
            }
            var po = db.PurchaseOrders.Find(poID);
            if (check== false)
            {
                po.Status = 6;
            }
            else if(check == true)
            {
                po.Status = 7;
            }
            po.TotalAmountPurchase = total;
            po.ReceivedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("ReturnPODetails", new { id = poID });
        }

        [NonAction]
        public void ChangeQuanInStock(string id, int quan)
        {
            var pl = db.ProductLines.Find(id);
            pl.QuantityInStock += quan;
            db.SaveChanges();
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
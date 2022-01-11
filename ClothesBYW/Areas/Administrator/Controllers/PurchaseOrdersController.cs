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
    public class PurchaseOrdersController : Controller
    {
        private ClothesBYWDbContext db = new ClothesBYWDbContext();
        private const string PO_CART_SESSION = "PO_CART_SESSION";

        private Repository<PurchaseOrder> repository = null;
        private PurchaseOrderRepository purchaseOrderRepository = null;
        private ProductRepository productRepository = null;
        private ProductLineRepository productLineRepository = null;
        public PurchaseOrdersController()
        {
            this.repository = new Repository<PurchaseOrder>();

            this.purchaseOrderRepository = new PurchaseOrderRepository();
            this.productRepository = new ProductRepository();
            this.productLineRepository = new ProductLineRepository();
        }
        public PurchaseOrdersController(Repository<PurchaseOrder> repository, PurchaseOrderRepository purchaseOrderRepository, ProductRepository productRepository, ProductLineRepository productLineRepository)
        {
            this.repository = repository;
            this.purchaseOrderRepository = purchaseOrderRepository;
            this.productRepository = productRepository;
            this.productLineRepository = productLineRepository;
        }

        // GET: Administrator/PurchaseOrders
        public ActionResult Index()
        {
            int count = db.PurchaseOrders.Where(x => x.Status == 1 || x.Status == 5).Count();
            TempData["POCount"] = count;
            TempData["ProductCount"] = productRepository.Count();
            var cart = Session[PO_CART_SESSION];
            var list = new List<POCartItem>();
            if (cart != null)
            {
                list = (List<POCartItem>)cart;
            }
            return View(db.PurchaseOrders.Where(x=> x.Status == 1 || x.Status == 5).ToList());
        }

        public void SetViewBag(int? selectedid = null)
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers.ToList(), "SupplierID", "Name", selectedid);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = purchaseOrderRepository.GetById(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderID,TotalAmountPurchase,CreatedDate,CreatedBy,ModifiledDate,ModifiledBy,ReceivedDate,SupplierID,Status")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                var po = new PurchaseOrder();
                int num = purchaseOrderRepository.Count();
                string username = Session["Username"].ToString();

                po.PurchaseOrderID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + num;
                po.CreatedDate = DateTime.Now;
                po.CreatedBy = username;
                po.Status = 1;
                po.SupplierID = purchaseOrder.SupplierID;
                po.TotalAmountPurchase = 0;

                var poSession = new PurchaseOrderModel();
                poSession.PurchaseOrderID = po.PurchaseOrderID;
                poSession.SupplierID = po.SupplierID;

                Session.Add(CC.PURCHASE_ORDER_SESSION, poSession);
                Session["PurchaseOrderID"] = poSession.PurchaseOrderID;
                Session["SupplierID"] = poSession.SupplierID;

                return RedirectToAction("AddProductIntoPO");
            }

            SetViewBag();
            return PartialView(purchaseOrder);
        }

        public ActionResult AddProductIntoPO()
        {
            int supplierID = Convert.ToInt32(Session["SupplierID"]);
            string poID = Session["PurchaseOrderID"].ToString();

            var productList = productLineRepository.GetProductLinesWithSupplier(supplierID);

            return View(productList);
        }


        [HttpGet]
        public ActionResult AddToPO(string plid)
        {
            var plSession = new ProductLineModel();
            plSession.ProductLineID = plid;

            Session.Add(CC.PRODUCT_LINE_SESSION, plSession);
            Session["ProductLineID"] = plSession.ProductLineID;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddToPO(AddPLToPO model)
        {
            string plID = Session["ProductLineID"].ToString();
            string poID = Session["PurchaseOrderID"].ToString();
            var productLine = productLineRepository.GetById(plID);
            var cart = Session[PO_CART_SESSION];

            if (cart != null)
            {
                var list = (List<POCartItem>)cart;
                if (list.Exists(x => x.ProductLine.ProductLineID == plID))
                {

                    foreach (var item in list)
                    {
                        if (item.ProductLine.ProductLineID == plID)
                        {
                            item.PurchaseQuantity += model.PurchaseQuantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new POCartItem();
                    item.ProductLine = productLine;
                    item.PurchaseQuantity = model.PurchaseQuantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[PO_CART_SESSION] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new POCartItem();
                item.ProductLine = productLine;
                item.PurchaseQuantity = model.PurchaseQuantity;
                var list = new List<POCartItem>();
                list.Add(item);
                //Gán vào session
                Session[PO_CART_SESSION] = list;
            }
            return RedirectToAction("AddProductIntoPO", new { id = poID });
        }

        public ActionResult ViewPOCart()
        {
            var cart = Session[PO_CART_SESSION];
            var list = new List<POCartItem>();
            if (cart != null)
            {
                list = (List<POCartItem>)cart;
            }
            return PartialView(list);
        }

        // Cart session 
        public ActionResult POCart()
        {
            var cart = Session[PO_CART_SESSION];
            var list = new List<POCartItem>();
            if (cart != null)
            {
                list = (List<POCartItem>)cart;
            }
            return View(list);
        }

        public JsonResult DeleteAll()
        {
            Session[PO_CART_SESSION] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(string id)
        {
            var sessionCart = (List<POCartItem>)Session[PO_CART_SESSION];
            sessionCart.RemoveAll(x => x.ProductLine.ProductLineID == id);
            Session[PO_CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<POCartItem>>(cartModel);
            var sessionCart = (List<POCartItem>)Session[PO_CART_SESSION];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.ProductLine.ProductLineID == item.ProductLine.ProductLineID);
                if (jsonItem != null)
                {
                    item.PurchaseQuantity = jsonItem.PurchaseQuantity;
                }
            }
            Session[PO_CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Save()
        {
            var cart = Session[PO_CART_SESSION];
            var list = new List<POCartItem>();
            if (cart != null)
            {
                list = (List<POCartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Save(string note)
        {

            try
            {
                var po = new PurchaseOrder();
                int num = purchaseOrderRepository.Count();
                //string username = Session["Username"].ToString();
                int supplierID = Convert.ToInt32(Session["SupplierID"]);
                string poID = Session["PurchaseOrderID"].ToString();

                po.PurchaseOrderID = poID;
                po.CreatedDate = DateTime.Now;
                //po.CreatedBy = username;
                po.Status = 1;
                po.SupplierID = supplierID;
                po.TotalAmountPurchase = 0;

                purchaseOrderRepository.Insert(po);
                purchaseOrderRepository.Save();

                var cart = (List<POCartItem>)Session[PO_CART_SESSION];
                int i = 0;
                foreach (var item in cart)
                {
                    i++;
                    var poDetail = new PurchaseOrderDetail();
                    poDetail.PurchaseOrderDetailID = po.PurchaseOrderID + i.ToString();
                    poDetail.ProductLineID = item.ProductLine.ProductLineID;
                    poDetail.PurchaseOrderID = po.PurchaseOrderID;
                    poDetail.QuantityPurchase = item.PurchaseQuantity;
                    db.PurchaseOrderDetails.Add(poDetail);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PODetails(string id)
        {
            //string username = Session["Username"].ToString();

            var po = purchaseOrderRepository.GetById(id);
            var poDetail = db.PurchaseOrderDetails.Where(d => d.PurchaseOrderID == id).ToList();
            var supplier = db.Suppliers.Find(po.SupplierID);


            PurchaseOrderDetails detail = new PurchaseOrderDetails();
            detail.PurchaseOrder = po;
            detail.POProduct = poDetail;
            detail.Supplier = supplier;

            return View(detail);
        }

        [HttpGet]
        public ActionResult ChangeStatus(string id)
        {
            var po = purchaseOrderRepository.GetById(id);
            var poSession = new PurchaseOrderModel();
            poSession.PurchaseOrderID = po.PurchaseOrderID;
            poSession.SupplierID = po.SupplierID;

            Session.Add(CC.PURCHASE_ORDER_SESSION, poSession);
            Session["PurchaseOrderID"] = poSession.PurchaseOrderID;
            Session["SupplierID"] = poSession.SupplierID;

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

            if (po.Status == 2)
            {
                //var q = new ActionAsPdf("PODetails", new { id = poID });
                //return q;
                return RedirectToAction("POInvoice", new { id = poID });
            }

            return RedirectToAction("PODetails", new { id = poID });
        }

        public ActionResult POInvoice(string id)
        {
            var po = purchaseOrderRepository.GetById(id);
            var poDetail = db.PurchaseOrderDetails.Where(d => d.PurchaseOrderID == id).ToList();
            var supplier = db.Suppliers.Find(po.SupplierID);


            PurchaseOrderDetails detail = new PurchaseOrderDetails();
            detail.PurchaseOrder = po;
            detail.POProduct = poDetail;
            detail.Supplier = supplier;

            return View(detail);
        }

        public ActionResult ExportPDF(string id)
        {
            string poID = Session["PurchaseOrderID"].ToString();
            var po = purchaseOrderRepository.GetById(poID);

            var q = new ActionAsPdf("POInvoice", new { id = po.PurchaseOrderID });
            return q;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string id)
        {
            var supplier = db.Suppliers.Find(id);
            var po = db.PurchaseOrders.Where(x => x.SupplierID == supplier.SupplierID);

            var fromEmail = new MailAddress("clothingbyw@gmail.com", "Clothing By Your Way");
            var toEmail = new MailAddress(supplier.Email);
            var fromEmailPassword = "efqpdrmrzytmwywi";

            string subject = "";
            string body = "";

            subject = "Đơn đặt hàng";
            body = "";

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
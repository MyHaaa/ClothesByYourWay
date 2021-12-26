using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClothesBYW.Models;
using ClothesBYW.Models.Customer;
using Models.Dao;
using Models.Dao.Customer;
using Models.EF;
using PayPal;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;

namespace ClothesBYW.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly string _clientId = "AXbmtas32SI21pgSmikTHZTRq4r47mjOlJiXwNNS4Iavn4IumnmoHDswVEP3sIZdumPz0ytLMdImKBuV";
        private readonly string _secretKey = "EByhj8dOvI9lxUo5xDfk6rZW4EGHzikoWcPR44XxNCXSL9Hze4jcG2cXibiRx_IUmX3tz0mxmh9j0OjF";
        ClothesBYWDbContext db = new ClothesBYWDbContext();
        // GET: ShoppingCart
        // GET: ShoppingCart
        public ActionResult Showcart()
        {
            if (Session["Models.GioHang"] == null)
                return View("EmptyCart");
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            return View(gh);
        }
        //Tao moi gio hang
        public Models.GioHang GetGioHang()
        {
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            if (gh == null || Session["Models.GioHang"] == null)
            {
                gh = new Models.GioHang();
                Session["Models.GioHang"] = gh;
            }
            return gh;
        }

        //them sp vao gio hang
        public ActionResult addtocart(string id)
        {
            var pro = db.ProductLines.SingleOrDefault(s => s.ProductLineID == id);
            if (pro != null)
            {
                GetGioHang().ThemSPVaoGioHang(pro);
            }

            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //update gio hang
        public ActionResult Update_Cart_Qua(FormCollection form)
        {
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            string id = (form["IDPro"]);
            ProductLine sp = db.ProductLines.Find(id);
            int qua = int.Parse(form["QualityPro"]);
            cart.update_sp(id, qua);
            return RedirectToAction("Showcart", "ShoppingCart");
        }
        //xoa gio hang
        public ActionResult Remove(string id)
        {
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            cart.XoaSP(id);
            return RedirectToAction("Showcart", "ShoppingCart");

        }
        public PartialViewResult BagCart()
        {
            int total_quality = 0;
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            if (cart != null)
            {
                total_quality = cart.TongSP();

            }
            ViewBag.QuantityCart = total_quality;
            return PartialView("BagCart");
        }
        public ActionResult XoaALL()
        {
            Models.GioHang cart = Session["Models.GioHang"] as Models.GioHang;
            cart.ClearCart();
            return RedirectToAction("Showcart", "ShoppingCart");
        }
        public ActionResult Check_out_success()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            if(UserLoginSingleton.GetInstance().GetAccount() == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            return View(gh);
        }
        [HttpPost]
        public ActionResult UpdateAccount(string name, string mobile, string email, string address)
        {
            var dao = new AccountDao();
            var newCus = dao.UpdateInfo(UserLoginSingleton.GetInstance().GetAccount().ID, name, mobile, email, address);
            UserLoginSingleton.Init(newCus.CustomerID, newCus.Name, newCus.Username, newCus.DateOfBirth, newCus.Phone, newCus.Address, newCus.Email);
            return RedirectToAction("CheckOut", "ShoppingCart");
        }
        public async Task PaypalCheckout()
        {
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);

            var listItems = new List<PurchaseUnitRequest>();
            listItems.Add(new PurchaseUnitRequest()
            {
                Description = "ClothesBYW",
                Items = new List<Item>()
            });
            foreach (var item in gh.Items)
            {
                listItems.FirstOrDefault().Items.Add(new Item()
                {
                    Name = item.sp.Product.ProductName,
                    UnitAmount = new Money()
                    {
                        CurrencyCode = "USD",
                        Value = item.Total().ToString()
                    },
                    Quantity = item.SoLuong.ToString(),
                    Sku = "sku",
                    Tax = new Money()
                    {
                        CurrencyCode = "USD",
                        Value = 0.ToString()
                    }
                }); 
            }

            var order = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = listItems,
                ApplicationContext = new ApplicationContext()
                {
                    ReturnUrl = "https://localhost:44366/ShoppingCart/CreateOrder",
                    CancelUrl = "https://localhost:44366/ShoppingCart/CheckOut"
                }
            };
            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(order);
            PayPalHttp.HttpResponse response = await client.Execute(request);
            var statusCode = response.StatusCode;
        }
        public ActionResult CreateOrder()
        {
            Models.GioHang gh = Session["Models.GioHang"] as Models.GioHang;
            var dao = new OrderDao();
            var listOrderDetail = new List<OrderDetail>();
            foreach(var item in gh.Items)
            {
                listOrderDetail.Add(new OrderDetail()
                {
                    PriceEach = item.Price,
                    ProductLineID = item.sp.ProductLineID,
                    QuantitySold = item.SoLuong
                });
            }
            var result = dao.CreateOrder(UserLoginSingleton.GetInstance().GetAccount().ID,listOrderDetail);
            gh.ClearCart();
            return RedirectToAction("Index", "Home");
        }
    }
}

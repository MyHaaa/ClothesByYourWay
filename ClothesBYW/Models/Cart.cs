using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesBYW.Models;
using Models.Dao;
using Models.EF;

namespace ClothesBYW.Models
{
    public class CartItem
    {
        public ProductLine sp { get; set; }
        public int SoLuong { get; set; }

        public decimal Price => (decimal)(sp.Product.Prices.First().RetailPrice);

        public decimal Total()
        {
            return (decimal)(sp.Product.Prices.First().RetailPrice * this.SoLuong);
        }

    }
    public class GioHang
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void ThemSPVaoGioHang(ProductLine sp, int sl = 1)
        {
            var item = Items.FirstOrDefault(s => s.sp.ProductLineID == sp.ProductLineID);
            if (item == null)
                items.Add(new CartItem
                {
                    sp = sp,



                    SoLuong = sl
                });
            else
            {
                item.SoLuong += sl;
            }
        }
        public int TongSP()
        {
            return items.Sum(s => s.SoLuong);
        }
        public decimal TongTien()
        {
            var total = items.Sum(s => s.SoLuong * s.sp.Product.Prices.First().StandardPrice);
            return (decimal)total;
        }
        public void update_sp(string id, int new_sp)
        {
            var itm = items.Find(s => s.sp.ProductLineID == id);
            if (itm != null && itm.SoLuong > 0)
            {
                itm.SoLuong = new_sp;
            }
        }
        public void XoaSP(string id)
        {
            items.RemoveAll(s => s.sp.ProductLineID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}
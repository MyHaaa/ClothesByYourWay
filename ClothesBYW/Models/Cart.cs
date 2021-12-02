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
        public Product sp { get; set; }
        public int SoLuong { get; set; }
    }
    public class GioHang
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void ThemSPVaoGioHang(Product sp, int sl = 1)
        {
            var item = Items.FirstOrDefault(s => s.sp.ProductID == sp.ProductID);
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
            var total = items.Sum(s => s.SoLuong * s.sp.Prices.First().StandardPrice);
            return (decimal)total;
        }
        public void update_sp(string id, int new_sp)
        {
            var itm = items.Find(s => s.sp.ProductID == id);
            if (itm != null && itm.SoLuong > 0)
            {
                itm.SoLuong = new_sp;
            }
        }
        public void XoaSP(string id)
        {
            items.RemoveAll(s => s.sp.ProductID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}
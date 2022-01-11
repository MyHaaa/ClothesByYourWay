using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class PurchaseOrderDetail
    {
    
        public string PurchaseOrderDetailID { get; set; }
        [Display(Name = "Mã đơn đặt hàng ")]
        public string PurchaseOrderID { get; set; }
        [Display(Name = "Mã dòng sản phẩm ")]
        public string ProductLineID { get; set; }
        [Display(Name = "Số lượng đặt mua ")]
        public long? QuantityPurchase { get; set; }
        [Display(Name = "Số lượng nhận ")]
        public long? QuantityReceived { get; set; }
        [Display(Name = "Trạng thái ")]
        public int? Status { get; set; }
        [Display(Name = "Giá đặt mua ")]
        public decimal? PricePurchase { get; set; }
        public virtual ProductLine ProductLine { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}

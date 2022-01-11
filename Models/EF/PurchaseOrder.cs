using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class PurchaseOrder
    {
        [Display(Name = "Mã đơn đặt hàng ")]
        public string PurchaseOrderID { get; set; }
        [Display(Name = "Tổng tiền ")]
        public decimal? TotalAmountPurchase { get; set; }

        [Display(Name = "Ngày tạo ")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Tạo bởi ")]
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày chỉnh sửa ")]
        public DateTime? ModifiledDate { get; set; }
        [Display(Name = "Chỉnh sửa bởi ")]
        public string ModifiledBy { get; set; }
        [Display(Name = "Ngày nhận đơn ")]
        public DateTime? ReceivedDate { get; set; }
        [Display(Name = "Trạng thái ")]
        public int? Status { get; set; }
        public int SupplierID { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class PurchaseOrder
    {
        public string PurchaseOrderID { get; set; }
        public decimal? TotalAmountPurchase { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiledDate { get; set; }
        public string ModifiledBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int? Status { get; set; }
        public int SupplierID { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}

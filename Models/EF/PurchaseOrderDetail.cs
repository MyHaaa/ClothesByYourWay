using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class PurchaseOrderDetail
    {
        public string PurchaseOrderDetailID { get; set; }
        public string PurchaseOrderID { get; set; }
        public string ProductLineID { get; set; }
        public long? QuantityPurchase { get; set; }
        public long? QuantityReceived { get; set; }
        public int? Status { get; set; }
        public virtual ProductLine ProductLine { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}

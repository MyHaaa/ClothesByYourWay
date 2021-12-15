namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class PurchaseOrderDetail
    {
        [StringLength(50)]
        public string PurchaseOrderDetailID { get; set; }

        [Required]
        [StringLength(50)]
        public string PurchaseOrderID { get; set; }

        [StringLength(50)]
        public string ProductLineID { get; set; }

        public long? QuantityPurchase { get; set; }

        public long? QuantityReceived { get; set; }

        public int? Status { get; set; }

        public virtual ProductLine ProductLine { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}

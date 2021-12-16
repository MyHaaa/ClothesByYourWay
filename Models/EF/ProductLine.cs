using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class ProductLine
    {
        public string ProductLineID { get; set; }
        public string ProductID { get; set; }
        public string Alias { get; set; }
        public int? Status { get; set; }
        public string Size { get; set; }
        public int? MinimumQuantityAvailable { get; set; }
        public int ColorID { get; set; }
        public long QuantityInStock { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}

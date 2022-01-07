using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class PurchaseOrderDetails
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public IEnumerable<PurchaseOrderDetail> POProduct { get; set; }
        public Price Price { get; set; }
        public Supplier Supplier { get; set; }
    }
}
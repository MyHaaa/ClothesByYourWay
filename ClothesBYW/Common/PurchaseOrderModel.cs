using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Common
{
    [Serializable]
    public class PurchaseOrderModel
    {
        public string PurchaseOrderID { get; set; }

        public int? SupplierID { get; set; }
    }
}
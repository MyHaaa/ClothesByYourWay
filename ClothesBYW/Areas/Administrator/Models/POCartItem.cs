using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ClothesBYW.Areas.Administrator.Models
{
    [Serializable]
    public class POCartItem
    {
        public ProductLine ProductLine { set; get; }
        public long PurchaseQuantity { set; get; }
    }
}
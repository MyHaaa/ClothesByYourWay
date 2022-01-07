using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class AddPLToPO
    {
        [Key]
        [StringLength(50)]
        public string ProductLineID { get; set; }

        public long PurchaseQuantity { get; set; }
    }
}
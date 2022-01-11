using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesBYW.Areas.Administrator.Models
{
    public class ChangStatusOrder
    {
        [Key]
        public string OrderID { get; set; }
        public int? StatusID { get; set; }
    }
}
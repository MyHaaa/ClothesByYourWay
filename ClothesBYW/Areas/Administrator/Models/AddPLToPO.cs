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

        [Display(Name = "Số lượng đặt mua ")]
        [Required(ErrorMessage = "Nhập số lượng cần đặt mua!")]
        [Range(1, 100)]
        public long PurchaseQuantity { get; set; }
    }
}
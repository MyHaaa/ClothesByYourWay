using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Voucher
    {
        [Display(Name = "Mã voucher ")]
        public string VoucherID { get; set; }

        [Display(Name = "Phần trăm giảm ")]
        public decimal? PercentageDiscount { get; set; }
        [Display(Name = "Giá được giảm ")]
        public decimal? AmountDiscount { get; set; }
        [Display(Name = "Ngày tạo ")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Ngày kết thúc ")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Trạng thái ")]
        public int? Status { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}

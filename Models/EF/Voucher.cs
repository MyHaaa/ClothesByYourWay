using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Voucher
    {
        public string VoucherID { get; set; }
        public decimal? PercentageDiscount { get; set; }
        public decimal? AmountDiscount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Order
    {
        [Display(Name = "Mã đơn hàng ")]
        public string OrderID { get; set; }
        [Display(Name = "Mã khách hàng ")]
        public string CustomerID { get; set; }

        [Display(Name = "Địa chỉ giao hàng ")]
        public string AddressShip { get; set; }

        [Display(Name = "Tổng tiền ")]
        public decimal? Total { get; set; }

        [Display(Name = "Ghi chú ")]
        public string Note { get; set; }

        [Display(Name = "Ngày tạo ")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Trạng thái ")]
        public int? Status { get; set; }

        [Display(Name = "Mã voucher ")]
        public string VoucherID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Voucher Voucher { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ShipperOrder> ShipperOrders { get; set; }
    }
}

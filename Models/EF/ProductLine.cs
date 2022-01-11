using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class ProductLine
    {
        [Display(Name = "Mã dòng sản phẩm ")]
        public string ProductLineID { get; set; }
        [Display(Name = "Mã sản phẩm ")]
        public string ProductID { get; set; }
        public string Alias { get; set; }
        [Display(Name = "Trạng thái ")]
        public int? Status { get; set; }
        [Display(Name = "Kích cỡ ")]
        public string Size { get; set; }
        [Display(Name = "Giá trị nhỏ nhất cho phép ")]
        public int? MinimumQuantityAvailable { get; set; }
        [Display(Name = "Mã màu ")]
        public int ColorID { get; set; }
        [Display(Name = "Số lượng hiện có trong kho ")]
        public long QuantityInStock { get; set; }
        [Display(Name = "Tạo bởi ")]
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày tạo ")]
        public DateTime? CreatedDate { get; set; }
        public int SupplierID { get; set; }
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}

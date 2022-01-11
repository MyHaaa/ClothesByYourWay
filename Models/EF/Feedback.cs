using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.EF
{
    public class Feedback
    {
        [Display(Name = "Mã Feedback ")]
        public long FeedBackID { get; set; }

        [Display(Name = "Mã khách hàng ")]
        public string CustomerID { get; set; }

        [Display(Name = "Mã khách hàng ")]
        public string ProductID { get; set; }

        [Display(Name = "Rating ")]
        public int? Star { get; set; }

        [Display(Name = "Tiêu đề ")]
        public string Title { get; set; }

        [Display(Name = "Nội dung ")]
        public string Content { get; set; }

        [Display(Name = "Ngày tạo ")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Trạng thái ")]
        public bool? Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}

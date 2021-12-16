using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class Feedback
    {
        public long FeedBackID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int? Star { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}

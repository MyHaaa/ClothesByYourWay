namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedback
    {
        public long FeedBackID { get; set; }

        [StringLength(50)]
        public string CustomerID { get; set; }

        [StringLength(50)]
        public string ProductID { get; set; }

        public int? Star { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}

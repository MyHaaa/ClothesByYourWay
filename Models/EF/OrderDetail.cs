namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [StringLength(50)]
        public string OrderDetailID { get; set; }

        [StringLength(50)]
        public string OrderID { get; set; }

        public decimal? PriceEach { get; set; }

        [StringLength(50)]
        public string ProductLineID { get; set; }

        public int? QuantitySold { get; set; }

        public virtual Order Order { get; set; }
        public virtual ProductLine ProductLine { get; set; }
    }
}

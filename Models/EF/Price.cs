namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Price
    {
        public int PriceID { get; set; }

        [StringLength(50)]
        public string ProductID { get; set; }

        public decimal? WholeSalePrice { get; set; }

        public decimal? RetailPrice { get; set; }

        public decimal? StandardPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}

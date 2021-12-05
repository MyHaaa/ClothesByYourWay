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

        [StringLength(50)]
        public string ProductID { get; set; }

        public int? QuantitySold { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public double Total
        {
            get
            {
                var price = this.Product.Prices.
                if (this.QuantitySold != null && price.Count > 0)
                {
                    //return (double)(this.QuantitySold * Price.Equals().);
                }
                return 0;
                if (this.QuantitySold != null)
                {
                    return 0;
                }
                return 0;

            }
        }
    }
}

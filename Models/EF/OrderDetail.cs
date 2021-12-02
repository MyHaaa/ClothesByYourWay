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
                //if (this.QuantitySold != null && Price.StandardPrice != null)
                //{
                //    return (double)(this.QuantitySold * this.DonGia);
                //}
                //return 0;
                //if (this.QuantitySold != null)
                //{
                //    return 0;
                //}
                return 0;

            }
        }
    }
}

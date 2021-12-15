namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        public long ProductImageID { get; set; }

        [StringLength(50)]
        public string ProductLineID { get; set; }

        public string ImageLink { get; set; }

        public virtual ProductLine ProductLine { get; set; }
    }
}

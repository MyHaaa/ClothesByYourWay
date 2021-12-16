using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class ProductImage
    {
        public long ProductImageID { get; set; }
        public string ProductLineID { get; set; }
        public string ImageLink { get; set; }
        public virtual ProductLine ProductLine { get; set; }
    }
}

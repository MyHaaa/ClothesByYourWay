using System;
using System.Collections.Generic;

namespace Models.EF
{
    public class ProductModification
    {
        public long PMID { get; set; }
        public string ProductID { get; set; }
        public string ModifiledBy { get; set; }
        public DateTime? ModifiledDate { get; set; }
        public string Note { get; set; }
        public virtual Product Product { get; set; }
    }
}

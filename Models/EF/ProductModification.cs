namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductModification
    {
        [Key]
        public long PMID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(25)]
        public string ModifiledBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string Note { get; set; }

        public virtual Product Product { get; set; }
    }
}

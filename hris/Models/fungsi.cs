namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fungsi")]
    public partial class fungsi
    {
        public int id { get; set; }

        [Column("fungsi")]
        [StringLength(255)]
        public string fungsi1 { get; set; }
    }
}

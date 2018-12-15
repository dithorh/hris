namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("divisi")]
    public partial class divisi
    {
        public int id { get; set; }

        [Column("divisi")]
        [StringLength(255)]
        public string divisi1 { get; set; }
    }
}

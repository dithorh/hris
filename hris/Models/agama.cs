namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("agama")]
    public partial class agama
    {
        public int id { get; set; }

        [Column("agama")]
        [StringLength(255)]
        public string agama1 { get; set; }
    }
}

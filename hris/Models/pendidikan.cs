namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pendidikan")]
    public partial class pendidikan
    {
        public int id { get; set; }

        [Column("pendidikan")]
        [StringLength(255)]
        public string pendidikan1 { get; set; }
    }
}

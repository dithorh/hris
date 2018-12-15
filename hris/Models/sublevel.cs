namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sublevel")]
    public partial class sublevel
    {
        public int id { get; set; }

        [Column("sublevel")]
        [StringLength(255)]
        public string sublevel1 { get; set; }
    }
}

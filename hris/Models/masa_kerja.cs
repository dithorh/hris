namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class masa_kerja
    {
        public int id { get; set; }

        [Column("masa_kerja")]
        [StringLength(255)]
        public string masa_kerja1 { get; set; }
    }
}

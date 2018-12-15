namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class golongan_bisnis
    {
        public int id { get; set; }

        [StringLength(255)]
        public string gol_bisnis { get; set; }
    }
}

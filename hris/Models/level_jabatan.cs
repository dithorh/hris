namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class level_jabatan
    {
        public int id { get; set; }

        [StringLength(255)]
        public string lvl { get; set; }
    }
}

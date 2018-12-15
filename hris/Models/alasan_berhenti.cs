namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class alasan_berhenti
    {
        public int id { get; set; }

        [StringLength(255)]
        public string alasan { get; set; }
    }
}

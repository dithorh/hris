namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class golongan_jabatan
    {
        public int id { get; set; }

        [StringLength(255)]
        public string jabatan { get; set; }
    }
}

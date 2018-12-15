namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("simp")]
    public partial class simp
    {
        public int id { get; set; }

        public int? karyawan_id { get; set; }

        [Column(TypeName = "text")]
        public string keperluan { get; set; }

        [Column(TypeName = "text")]
        public string keterangan { get; set; }

        public DateTime? tanggal_pengajuan { get; set; }

        [StringLength(10)]
        public string status_approval1 { get; set; }

        [StringLength(10)]
        public string status_approval2 { get; set; }

        public DateTime? tanggal_approval { get; set; }
    }
}

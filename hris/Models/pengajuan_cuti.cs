namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pengajuan_cuti
    {
        [Key]
        public int pengajuan_cuti_id { get; set; }

        public int? karyawan_id { get; set; }

        [StringLength(15)]
        public string jenis_cuti { get; set; }

        public string alasan { get; set; }

        public string keterangan { get; set; }

        public int? jml_hari { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? tgl_mulai_cuti { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? tgl_selesai_cuti { get; set; }

        public DateTime? tgl_pengajuan { get; set; }

        public DateTime? tgl_approval1 { get; set; }

        [StringLength(10)]
        public string status_approval1 { get; set; }

        public DateTime? tgl_approval2 { get; set; }

        [StringLength(10)]
        public string status_approval2 { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modified { get; set; }
    }
}

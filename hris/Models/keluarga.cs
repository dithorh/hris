namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("keluarga")]
    public partial class keluarga
    {
        [Key]
        public int keluarga_id { get; set; }

        public int? karyawan_id { get; set; }

        [StringLength(50)]
        public string nama { get; set; }

        [StringLength(10)]
        public string jenis_kelamin { get; set; }

        [StringLength(50)]
        public string tgl_lahir { get; set; }

        [StringLength(20)]
        public string hubungan { get; set; }

        [StringLength(20)]
        public string pend_terakhir { get; set; }

        [StringLength(50)]
        public string pekerjaan { get; set; }

        [StringLength(50)]
        public string perusahaan { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modified { get; set; }

        public virtual karyawan karyawan { get; set; }
    }
}

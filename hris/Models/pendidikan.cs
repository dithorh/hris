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
        [Key]
        public int pendidikan_id { get; set; }

        public int? karyawan_id { get; set; }

        public int? sekolah_id { get; set; }

        public int? jurusan_id { get; set; }

        [StringLength(20)]
        public string jenjang { get; set; }

        public int? tahun_masuk { get; set; }

        public int? tahun_lulus { get; set; }

        public float? ipk { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modfied { get; set; }

        public virtual karyawan karyawan { get; set; }

        public virtual ref_jurusan ref_jurusan { get; set; }

        public virtual ref_sekolah ref_sekolah { get; set; }
    }
}

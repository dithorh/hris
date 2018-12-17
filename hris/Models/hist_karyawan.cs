namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class hist_karyawan
    {
        [Key]
        public int hist_karyawan_id { get; set; }

        public int? karyawan_id { get; set; }

        public int? divisi_id { get; set; }

        public int? cctr_id { get; set; }

        [StringLength(50)]
        public string job_title { get; set; }

        public int? gol_jabatan_id { get; set; }

        public int? lvl_jabatan_id { get; set; }

        public int? sub_lvl_jabatan_id { get; set; }

        public int? status_karyawan_id { get; set; }

        public int? lokasi_kerja_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tgl_mulai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tgl_selesai { get; set; }

        public string keterangan { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modified { get; set; }

        [StringLength(20)]
        public string created_by { get; set; }

        [StringLength(50)]
        public string updated_by { get; set; }

        public virtual ref_cctr ref_cctr { get; set; }

        public virtual ref_divisi ref_divisi { get; set; }

        public virtual ref_gol_jabatan ref_gol_jabatan { get; set; }

        public virtual karyawan karyawan { get; set; }

        public virtual ref_lokasi_kerja ref_lokasi_kerja { get; set; }

        public virtual ref_lvl_jabatan ref_lvl_jabatan { get; set; }

        public virtual ref_status_karyawan ref_status_karyawan { get; set; }

        public virtual ref_sub_lvl_jabatan ref_sub_lvl_jabatan { get; set; }
    }
}

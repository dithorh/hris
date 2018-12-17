namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pengalaman_kerja
    {
        [Key]
        public int pengalaman_kerja_id { get; set; }

        public int? karyawan_id { get; set; }

        [StringLength(50)]
        public string nama_perusahaan { get; set; }

        [StringLength(50)]
        public string bidang_bisnis { get; set; }

        [StringLength(15)]
        public string telp { get; set; }

        [StringLength(50)]
        public string alamat { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modfied { get; set; }
    }
}

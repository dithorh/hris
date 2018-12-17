namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("karyawan")]
    public partial class karyawan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public karyawan()
        {
            hist_karyawan = new HashSet<hist_karyawan>();
            keluargas = new HashSet<keluarga>();
            pendidikans = new HashSet<pendidikan>();
            pengajuan_cuti = new HashSet<pengajuan_cuti>();
        }

        [Key]
        public int karyawan_id { get; set; }

        [StringLength(20)]
        public string user_id { get; set; }

        [StringLength(15)]
        public string no_karyawan { get; set; }

        [StringLength(20)]
        public string nama_karyawan { get; set; }

        [StringLength(3)]
        public string inisial { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        [StringLength(15)]
        public string ktp { get; set; }

        [StringLength(15)]
        public string kartu_keluarga { get; set; }

        [StringLength(20)]
        public string npwp { get; set; }

        [StringLength(15)]
        public string bpjs_kesehatan { get; set; }

        [StringLength(15)]
        public string bpjs_ketanagakerjaan { get; set; }

        [StringLength(10)]
        public string jenis_kelamin { get; set; }

        [StringLength(15)]
        public string tempat_lahir { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tgl_lahir { get; set; }

        public double? usia { get; set; }

        [StringLength(10)]
        public string agama { get; set; }

        public string alamat { get; set; }

        [StringLength(15)]
        public string telp_rumah { get; set; }

        [StringLength(15)]
        public string hp { get; set; }

        [StringLength(15)]
        public string status_perkawinan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tgl_masuk { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tgl_berhenti { get; set; }

        [StringLength(20)]
        public string no_rek { get; set; }

        [StringLength(20)]
        public string no_rek_bni { get; set; }

        public double? masa_kerja { get; set; }

        [StringLength(20)]
        public string kelompok_masa_kerja { get; set; }

        [StringLength(20)]
        public string kelompok_usia { get; set; }

        [StringLength(20)]
        public string status_kerja { get; set; }

        public bool asuransi_kesehatan { get; set; }

        public bool asuransi_jiwa { get; set; }

        public bool pesangon { get; set; }

        [Column(TypeName = "text")]
        public string keterangan { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modified { get; set; }

        [StringLength(20)]
        public string created_by { get; set; }

        [StringLength(20)]
        public string updated_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hist_karyawan> hist_karyawan { get; set; }

        public virtual user_login user_login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<keluarga> keluargas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pendidikan> pendidikans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pengajuan_cuti> pengajuan_cuti { get; set; }
    }
}

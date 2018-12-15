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
        [Key]
        [Column(Order = 0)]
        public int NOABSEN { get; set; }

        [StringLength(255)]
        public string NAMA_LENGKAP { get; set; }

        [StringLength(255)]
        public string STATUS_KARYAWAN { get; set; }

        [StringLength(255)]
        public string STATUS_TEAM { get; set; }

        [StringLength(255)]
        public string ELNUSA_STATUS { get; set; }

        [StringLength(255)]
        public string JOBGRADE { get; set; }

        [StringLength(255)]
        public string JABATAN { get; set; }

        [StringLength(255)]
        public string ELNUSA_JOBGRADE { get; set; }

        [StringLength(255)]
        public string ELNUSA_EDUCATION { get; set; }

        [StringLength(255)]
        public string PEND_TERAKHIR { get; set; }

        [StringLength(255)]
        public string INISIAL { get; set; }

        [StringLength(255)]
        public string KARYAWAN_ID { get; set; }

        [StringLength(255)]
        public string BAND { get; set; }

        [StringLength(255)]
        public string SUB_BAND { get; set; }

        [StringLength(255)]
        public string DIVISI { get; set; }

        [StringLength(255)]
        public string GOLONGAN_BISNIS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TANGGAL_MASUK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TGL_LAHIR { get; set; }

        [StringLength(255)]
        public string TEMPAT_LAHIR { get; set; }

        [StringLength(255)]
        public string JENIS_KELAMIN { get; set; }

        [StringLength(255)]
        public string AGAMA { get; set; }

        [StringLength(255)]
        public string ALAMAT { get; set; }

        [StringLength(255)]
        public string TELP_RUMAH { get; set; }

        [StringLength(255)]
        public string HP { get; set; }

        [StringLength(255)]
        public string STATUS { get; set; }

        [StringLength(255)]
        public string NAMA_SEKOLAH { get; set; }

        [StringLength(255)]
        public string JURUSAN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TANGGAL_BERHENTI { get; set; }

        [StringLength(255)]
        public string GOLONGAN { get; set; }

        [StringLength(255)]
        public string KETERANGAN { get; set; }

        [StringLength(255)]
        public string NOMOR_REKENING { get; set; }

        [StringLength(255)]
        public string NOMOR_REKENING_BNI { get; set; }

        [StringLength(255)]
        public string FOTO { get; set; }

        public double? MASA_KERJA { get; set; }

        [StringLength(255)]
        public string KELOMPOK_MASA_KERJA { get; set; }

        [StringLength(255)]
        public string USIA { get; set; }

        [StringLength(255)]
        public string KELOMPOK_USIA { get; set; }

        [StringLength(255)]
        public string LOKASI_KERJA { get; set; }

        [StringLength(255)]
        public string STATUS_KERJA { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool ABSEN { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool ASURANSI_KESEHATAN { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool ASURANSI_JIWA { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool PESANGON { get; set; }

        [StringLength(255)]
        public string ALASAN_BERHENTI { get; set; }

        [StringLength(255)]
        public string ELNUSA_DEPARTMENT { get; set; }

        [StringLength(255)]
        public string TECHNICAL_TALENT { get; set; }

        [StringLength(255)]
        public string KTP { get; set; }

        [StringLength(255)]
        public string KARTU_KELUARGA { get; set; }

        [StringLength(255)]
        public string NPWP { get; set; }

        [StringLength(255)]
        public string BPJS_KESEHATAN { get; set; }

        [StringLength(50)]
        public string BPJS_KETANAGAKERJAAN { get; set; }
    }
}

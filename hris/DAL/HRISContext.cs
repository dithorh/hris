namespace hris.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRISContext : DbContext
    {
        public HRISContext()
            : base("name=HRISContext")
        {
        }

        public virtual DbSet<hist_karyawan> hist_karyawan { get; set; }
        public virtual DbSet<karyawan> karyawan { get; set; }
        public virtual DbSet<keluarga> keluarga { get; set; }
        public virtual DbSet<pendidikan> pendidikan { get; set; }
        public virtual DbSet<ref_cctr> ref_cctr { get; set; }
        public virtual DbSet<ref_divisi> ref_divisi { get; set; }
        public virtual DbSet<ref_gol_jabatan> ref_gol_jabatan { get; set; }
        public virtual DbSet<ref_jurusan> ref_jurusan { get; set; }
        public virtual DbSet<ref_lokasi_kerja> ref_lokasi_kerja { get; set; }
        public virtual DbSet<ref_lvl_jabatan> ref_lvl_jabatan { get; set; }
        public virtual DbSet<ref_sekolah> ref_sekolah { get; set; }
        public virtual DbSet<ref_status_karyawan> ref_status_karyawan { get; set; }
        public virtual DbSet<ref_sub_lvl_jabatan> ref_sub_lvl_jabatan { get; set; }
        public virtual DbSet<pengajuan_cuti> pengajuan_cuti { get; set; }
        public virtual DbSet<pengalaman_kerja> pengalaman_kerja { get; set; }
        public virtual DbSet<user_login> user_login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hist_karyawan>()
                .Property(e => e.job_title)
                .IsUnicode(false);

            modelBuilder.Entity<hist_karyawan>()
                .Property(e => e.keterangan)
                .IsUnicode(false);

            modelBuilder.Entity<hist_karyawan>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<hist_karyawan>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.no_karyawan)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.nama_karyawan)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.inisial)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.ktp)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.kartu_keluarga)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.npwp)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.bpjs_kesehatan)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.bpjs_ketanagakerjaan)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.jenis_kelamin)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.tempat_lahir)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.agama)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.alamat)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.telp_rumah)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.hp)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.status_perkawinan)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.no_rek)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.no_rek_bni)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.kelompok_masa_kerja)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.kelompok_usia)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.status_kerja)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.keterangan)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<karyawan>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.nama)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.jenis_kelamin)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.tgl_lahir)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.hubungan)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.pend_terakhir)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.pekerjaan)
                .IsUnicode(false);

            modelBuilder.Entity<keluarga>()
                .Property(e => e.perusahaan)
                .IsUnicode(false);

            modelBuilder.Entity<ref_cctr>()
                .Property(e => e.cctr)
                .IsUnicode(false);

            modelBuilder.Entity<ref_divisi>()
                .Property(e => e.nama_divisi)
                .IsUnicode(false);

            modelBuilder.Entity<ref_gol_jabatan>()
                .Property(e => e.nama_jabatan)
                .IsUnicode(false);

            modelBuilder.Entity<ref_jurusan>()
                .Property(e => e.nama_jurusan)
                .IsUnicode(false);

            modelBuilder.Entity<ref_lokasi_kerja>()
                .Property(e => e.nama_lokasi)
                .IsUnicode(false);

            modelBuilder.Entity<ref_lokasi_kerja>()
                .Property(e => e.alamat)
                .IsUnicode(false);

            modelBuilder.Entity<ref_lokasi_kerja>()
                .Property(e => e.kota)
                .IsUnicode(false);

            modelBuilder.Entity<ref_lokasi_kerja>()
                .Property(e => e.propinsi)
                .IsUnicode(false);

            modelBuilder.Entity<ref_lvl_jabatan>()
                .Property(e => e.lvl_jabatan)
                .IsUnicode(false);

            modelBuilder.Entity<ref_sekolah>()
                .Property(e => e.nama_sekolah)
                .IsUnicode(false);

            modelBuilder.Entity<ref_sekolah>()
                .Property(e => e.alamat)
                .IsUnicode(false);

            modelBuilder.Entity<ref_status_karyawan>()
                .Property(e => e.status_karyawan)
                .IsUnicode(false);

            modelBuilder.Entity<ref_sub_lvl_jabatan>()
                .Property(e => e.sub_lvl_jabatan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<pengajuan_cuti>()
                .Property(e => e.jenis_cuti)
                .IsUnicode(false);

            modelBuilder.Entity<pengajuan_cuti>()
                .Property(e => e.alasan)
                .IsUnicode(false);

            modelBuilder.Entity<pengajuan_cuti>()
                .Property(e => e.keterangan)
                .IsUnicode(false);

            modelBuilder.Entity<pengajuan_cuti>()
                .Property(e => e.status_approval1)
                .IsUnicode(false);

            modelBuilder.Entity<pengajuan_cuti>()
                .Property(e => e.status_approval2)
                .IsUnicode(false);

            modelBuilder.Entity<pengalaman_kerja>()
                .Property(e => e.nama_perusahaan)
                .IsUnicode(false);

            modelBuilder.Entity<pengalaman_kerja>()
                .Property(e => e.bidang_bisnis)
                .IsUnicode(false);

            modelBuilder.Entity<pengalaman_kerja>()
                .Property(e => e.telp)
                .IsUnicode(false);

            modelBuilder.Entity<pengalaman_kerja>()
                .Property(e => e.alamat)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.vcode)
                .IsUnicode(false);

            modelBuilder.Entity<user_login>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}

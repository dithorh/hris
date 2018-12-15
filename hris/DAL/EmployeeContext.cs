namespace hris.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<agama> agama { get; set; }
        public virtual DbSet<alasan_berhenti> alasan_berhenti { get; set; }
        public virtual DbSet<cctr> cctr { get; set; }
        public virtual DbSet<divisi> divisi { get; set; }
        public virtual DbSet<fungsi> fungsi { get; set; }
        public virtual DbSet<golongan_bisnis> golongan_bisnis { get; set; }
        public virtual DbSet<golongan_jabatan> golongan_jabatan { get; set; }
        public virtual DbSet<karyawan> karyawan { get; set; }
        public virtual DbSet<level_jabatan> level_jabatan { get; set; }
        public virtual DbSet<lokasi_kerja> lokasi_kerja { get; set; }
        public virtual DbSet<masa_kerja> masa_kerja { get; set; }
        public virtual DbSet<pendidikan> pendidikan { get; set; }
        public virtual DbSet<status_pegawai> status_pegawai { get; set; }
        public virtual DbSet<sublevel> sublevel { get; set; }
        public virtual DbSet<simp> simp { get; set; }
        public virtual DbSet<user_login> user_login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

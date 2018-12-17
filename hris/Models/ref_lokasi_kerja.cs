namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ref_lokasi_kerja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ref_lokasi_kerja()
        {
            hist_karyawan = new HashSet<hist_karyawan>();
        }

        [Key]
        public int lokasi_kerja_id { get; set; }

        [StringLength(50)]
        public string nama_lokasi { get; set; }

        public string alamat { get; set; }

        [StringLength(20)]
        public string kota { get; set; }

        [StringLength(20)]
        public string propinsi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hist_karyawan> hist_karyawan { get; set; }
    }
}

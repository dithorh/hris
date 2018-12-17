namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ref_lvl_jabatan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ref_lvl_jabatan()
        {
            hist_karyawan = new HashSet<hist_karyawan>();
        }

        [Key]
        public int lvl_jabatan_id { get; set; }

        [StringLength(3)]
        public string lvl_jabatan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hist_karyawan> hist_karyawan { get; set; }
    }
}

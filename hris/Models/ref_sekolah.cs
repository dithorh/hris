namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ref_sekolah
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ref_sekolah()
        {
            pendidikans = new HashSet<pendidikan>();
        }

        [Key]
        public int sekolah_id { get; set; }

        [StringLength(20)]
        public string nama_sekolah { get; set; }

        [StringLength(50)]
        public string alamat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pendidikan> pendidikans { get; set; }
    }
}

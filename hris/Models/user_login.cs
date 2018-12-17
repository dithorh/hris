namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_login()
        {
            karyawans = new HashSet<karyawan>();
        }

        [Key]
        [StringLength(20)]
        public string user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(10)]
        public string vcode { get; set; }

        [StringLength(10)]
        public string role { get; set; }

        public bool status { get; set; }

        public DateTime? date_created { get; set; }

        public DateTime? date_modified { get; set; }

        public DateTime? last_login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<karyawan> karyawans { get; set; }
    }
}

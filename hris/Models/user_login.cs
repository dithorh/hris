namespace hris.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_login
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(10)]
        public string vcode { get; set; }

        [StringLength(20)]
        public string role { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_created { get; set; }

        [Column(TypeName = "date")]
        public DateTime? last_login { get; set; }
    }
}

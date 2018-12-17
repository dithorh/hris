using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hris.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public string no_karyawan { get; set; }
        public string inisial { get; set; }
        public DateTime? tgl_masuk { get; set; }
        public string divisi { get; set; }
        public string job_title { get; set; }
        public string status_karyawan { get; set; }
        public string lokasi_kerja { get; set; }
        public string status_kerja { get; set; }
        public string keterangan { get; set; }
    }
}
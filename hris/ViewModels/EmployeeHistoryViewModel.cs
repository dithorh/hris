using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hris.ViewModels
{
    public class EmployeeHistoryViewModel
    {
        public int hist_karyawan_id { get; set; }

        public string divisi { get; set; }

        public string cctr { get; set; }

        public string job_title { get; set; }

        public string jabatan { get; set; }

        public string lvl_jabatan { get; set; }

        public string sub_lvl_jabatan { get; set; }

        public string status_karyawan { get; set; }

        public string lokasi_kerja { get; set; }

        public DateTime? tgl_mulai { get; set; }

        public DateTime? tgl_selesai { get; set; }

        public string keterangan { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hris.ViewModels
{
    public class LeaveApprovalViewModel
    {
        public int pengajuan_cuti_id { get; set; }

        public string nama_karyawan { get; set; }

        public DateTime? tgl_mulai_cuti { get; set; }

        public DateTime? tgl_selesai_cuti { get; set; }

        public int? jml_hari { get; set; }

        public string jenis_cuti { get; set; }

        public string alasan { get; set; }

        public DateTime? tgl_pengajuan { get; set; }

        public string status_approval1 { get; set; }

        public DateTime? tgl_approval1 { get; set; }

        public string status_approval2 { get; set; }

        public DateTime? tgl_approval2 { get; set; }
    }
}
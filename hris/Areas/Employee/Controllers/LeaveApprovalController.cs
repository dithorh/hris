using hris.Models;
using hris.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Admin.Controllers
{
    public class LeaveApprovalController : Controller
    {
        private HRISContext db = new HRISContext();
       
        // GET: Admin/LeaveApproval
        public ActionResult Index()
        {
            var empID = (int)Session["emp_id"];
            var leaveApproval = (from k in db.karyawan
                         join pc in db.pengajuan_cuti on k.karyawan_id equals pc.karyawan_id
                         join hk in db.hist_karyawan on k.karyawan_id equals hk.karyawan_id
                         where hk.divisi_id == 6 &&
                         hk.gol_jabatan_id == 6
                         select new ApprovalLeaveViewModel
                         {
                             karyawan_id = k.karyawan_id,
                             tgl_mulai_cuti = pc.tgl_mulai_cuti,
                             tgl_selesai_cuti = pc.tgl_selesai_cuti,
                             jml_hari = pc.jml_hari,
                             jenis_cuti = pc.jenis_cuti,
                             alasan = pc.alasan,
                             tgl_pengajuan = pc.tgl_pengajuan,
                             status_approval1 = pc.status_approval1,
                             status_approval2 = pc.status_approval2
                         }).ToList();

            return View(leaveApproval);
        }
    }
}
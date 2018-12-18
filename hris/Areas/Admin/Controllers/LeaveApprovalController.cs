using hris.Handler;
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
        [SessionTimeout]
        public ActionResult Index()
        {
            var empID = (int)Session["emp_id"];
            var leaveApproval = (from f in db.hist_karyawan
                                 join k in db.karyawan on f.karyawan_id equals k.karyawan_id
                                 join pc in db.pengajuan_cuti on k.karyawan_id equals pc.karyawan_id
                                 group new
                                 {
                                     k.nama_karyawan,
                                     pc.pengajuan_cuti_id,
                                     pc.tgl_mulai_cuti,
                                     pc.tgl_selesai_cuti,
                                     pc.jml_hari,
                                     pc.jenis_cuti,
                                     pc.alasan,
                                     pc.tgl_pengajuan,
                                     pc.status_approval1,
                                     pc.status_approval2,
                                     f.tgl_mulai
                                 } by f.karyawan_id into g
                                 select g.OrderByDescending(o => o.tgl_mulai).FirstOrDefault());
            //select new LeaveApprovalViewModel
            //{
            //    nama_karyawan = g.Select(s => s.k.nama_karyawan).ToString()
            //    pengajuan_cuti_id = g.Select(s => s.pc.pengajuan_cuti_id).FirstOrDefault(),
            //    tgl_mulai_cuti = Convert.ToDateTime(g.Select(s => s.pc.tgl_mulai_cuti)),
            //    tgl_selesai_cuti = Convert.ToDateTime(g.Select(s => s.pc.tgl_selesai_cuti)),
            //    jml_hari = g.Select(s => s.pc.jml_hari).FirstOrDefault(),
            //    jenis_cuti = g.Select(s => s.k.nama_karyawan).ToString(),
            //    alasan = g.Select(s => s.k.nama_karyawan).ToString(),
            //    tgl_pengajuan = Convert.ToDateTime(g.Select(s => s.k.nama_karyawan).ToString()),
            //    status_approval1 = g.Select(s => s.k.nama_karyawan).ToString(),
            //    status_approval2 = g.Select(s => s.k.nama_karyawan).ToString()
            //});
            //g.OrderByDescending(o => o.f.tgl_mulai).FirstOrDefault());

            return View(leaveApproval);
        }
    }
}
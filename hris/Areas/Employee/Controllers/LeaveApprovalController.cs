using hris.Handler;
using hris.Models;
using hris.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class LeaveApprovalController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Employee/LeaveApproval
        [SessionTimeout]
        public ActionResult Index()
        {
            var empID = (int)Session["emp_id"];
            var divisiID = (int)Session["divisi_id"];
            var pos = (int)Session["pos"];

            var query = (from f in db.hist_karyawan
                         join k in db.karyawan on f.karyawan_id equals k.karyawan_id
                         join pc in db.pengajuan_cuti on k.karyawan_id equals pc.karyawan_id
                         group new LeaveApprovalViewModel
                         {
                             nama_karyawan = k.nama_karyawan,
                             pengajuan_cuti_id = pc.pengajuan_cuti_id,
                             divisi_id = f.divisi_id,
                             gol_jabatan_id = f.gol_jabatan_id,
                             tgl_mulai_cuti = pc.tgl_mulai_cuti,
                             tgl_selesai_cuti = pc.tgl_selesai_cuti,
                             jml_hari = pc.jml_hari,
                             jenis_cuti = pc.jenis_cuti,
                             alasan = pc.alasan,
                             tgl_pengajuan = pc.tgl_pengajuan,
                             status_approval1 = pc.status_approval1,
                             status_approval2 = pc.status_approval2,
                             tgl_mulai = f.tgl_mulai
                         } by new { f.karyawan_id, pc.pengajuan_cuti_id } into g
                         select g.OrderByDescending(o => o.tgl_mulai).AsQueryable().FirstOrDefault());

            if (pos == 3)
                query = query.Where(w => w.gol_jabatan_id == 4 || w.gol_jabatan_id == 6 && w.divisi_id == divisiID);
            else if (pos == 4)
                query = query.Where(w => w.gol_jabatan_id == 6 && w.divisi_id == divisiID);

            return View(query.ToList());
        }

        [ValidateAntiForgeryToken]
        public JsonResult Edit(LeaveApprovalViewModel approvalLeave)
        {
            var approval = db.pengajuan_cuti.Find(approvalLeave.pengajuan_cuti_id);
            approval.status_approval1 = approvalLeave.status_approval1;
            approval.tgl_approval1 = approvalLeave.tgl_approval1;
            approval.date_modified = DateTime.Now;

            if (TryUpdateModel(approvalLeave))
            {
                try
                {
                    db.SaveChanges();

                    return Json("0", JsonRequestBehavior.AllowGet);
                }
                catch (DataException)
                {
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
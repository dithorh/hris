using hris.Handler;
using hris.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class LeaveController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Employee/Leave
        [SessionTimeout]
        public ActionResult Index()
        {
            var empID = (int)Session["emp_id"];
            var leave = (from t in db.pengajuan_cuti
                         where t.karyawan_id == empID
                         select t).ToList();

            return View(leave);
        }

        [SessionTimeout]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(pengajuan_cuti pengajuan_Cuti)
        {
            try
            {
                pengajuan_Cuti.karyawan_id = (int)Session["emp_id"];
                pengajuan_Cuti.tgl_pengajuan = DateTime.Now;
                pengajuan_Cuti.status_approval1 = "Pending";

                if (new[] { "Izin", "Setengah Hari", "Potong Gaji" }.Contains(pengajuan_Cuti.jenis_cuti))
                {
                    pengajuan_Cuti.status_approval2 = "Approved";
                    pengajuan_Cuti.tgl_approval1 = DateTime.Now;
                }
                else
                {
                    pengajuan_Cuti.status_approval2 = "Pending";
                }

                pengajuan_Cuti.date_created = DateTime.Now;

                db.pengajuan_cuti.Add(pengajuan_Cuti);
                db.SaveChanges();

                return Json("0", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pengajuan_cuti pengajuan_Cuti = db.pengajuan_cuti.Find(id);

            if (pengajuan_Cuti == null)
            {
                return HttpNotFound();
            }
            return View(pengajuan_Cuti);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public JsonResult EditPost(pengajuan_cuti pengajuan_Cuti)
        {
            var leave = db.pengajuan_cuti.Find(pengajuan_Cuti.pengajuan_cuti_id);
            leave.tgl_mulai_cuti = pengajuan_Cuti.tgl_mulai_cuti;
            leave.tgl_selesai_cuti = pengajuan_Cuti.tgl_selesai_cuti;
            leave.jenis_cuti = pengajuan_Cuti.jenis_cuti;
            leave.alasan = pengajuan_Cuti.alasan;
            leave.date_modified = DateTime.Now;

            if (TryUpdateModel(pengajuan_Cuti))
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int? id)
        {
            try
            {
                pengajuan_cuti pengajuan_Cuti = db.pengajuan_cuti.Find(id);
                db.pengajuan_cuti.Remove(pengajuan_Cuti);
                db.SaveChanges();
                return Json("0", JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
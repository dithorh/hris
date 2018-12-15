using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hris.Helpers;
using hris.Models;
using System.Net;
using System.Data.Entity.Validation;
using hris.Handler;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;

namespace hris.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        private EmployeeHelper helper = new EmployeeHelper();

        public ActionResult List()
        {
            var karyawan = db.karyawan.ToList();

            return View(karyawan);
        }

        [HttpPost]
        public string List(int? draw, int? start, int? length)
        {
            var search = Request["search[value]"];
            var totalRecords = 0;
            var recordsFiltered = 0;
            start = start.HasValue ? start / 10 : 0;

            var karyawan = new EmployeeHelper().GetPaginated(search, start.Value, length ?? 10, out totalRecords, out recordsFiltered);

            return JsonConvert.SerializeObject(karyawan);
        }

        public ActionResult Create()
        {
            ViewBag.Agama = helper.GetDropDownList("agama", "agama");
            ViewBag.AlasanBerhenti = helper.GetDropDownList("alasan_berhenti", "alasan");
            ViewBag.CCTR = helper.GetDropDownList("cctr", "cctr");
            ViewBag.Divisi = helper.GetDropDownList("divisi", "divisi");
            ViewBag.Fungsi = helper.GetDropDownList("fungsi", "fungsi");
            ViewBag.GolBisnis = helper.GetDropDownList("golongan_bisnis", "gol_bisnis");
            ViewBag.GolJabatan = helper.GetDropDownList("golongan_jabatan", "jabatan");
            ViewBag.LvlJabatan = helper.GetDropDownList("level_jabatan", "lvl");
            ViewBag.LokasiKerja = helper.GetDropDownList("lokasi_kerja", "lokasi");
            ViewBag.MasaKerja = helper.GetDropDownList("masa_kerja", "masa_kerja");
            ViewBag.Pendidikan = helper.GetDropDownList("pendidikan", "pendidikan");
            ViewBag.StatusPegawai = helper.GetDropDownList("status_pegawai", "status");
            ViewBag.SubLvl = helper.GetDropDownList("sublevel", "sublevel");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(karyawan karyawan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.karyawan.Add(karyawan);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);

                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("List");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = db.karyawan.SingleOrDefault(m => m.NOABSEN == id);
            var employee = (from k in db.karyawan
                            where k.NOABSEN == id
                            select k).ToList();

            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.Karyawan = employee;
            ViewBag.Agama = helper.GetDropDownList("agama", "agama", query.AGAMA);
            ViewBag.AlasanBerhenti = helper.GetDropDownList("alasan_berhenti", "alasan", query.ALASAN_BERHENTI);
            ViewBag.CCTR = helper.GetDropDownList("cctr", "cctr");
            ViewBag.Divisi = helper.GetDropDownList("divisi", "divisi", query.DIVISI);
            ViewBag.Fungsi = helper.GetDropDownList("fungsi", "fungsi");
            ViewBag.GolBisnis = helper.GetDropDownList("golongan_bisnis", "gol_bisnis", query.GOLONGAN_BISNIS);
            ViewBag.GolJabatan = helper.GetDropDownList("golongan_jabatan", "jabatan", query.GOLONGAN);
            ViewBag.LvlJabatan = helper.GetDropDownList("level_jabatan", "lvl", query.JABATAN);
            ViewBag.LokasiKerja = helper.GetDropDownList("lokasi_kerja", "lokasi", query.LOKASI_KERJA);
            ViewBag.MasaKerja = helper.GetDropDownList("masa_kerja", "masa_kerja", query.MASA_KERJA.ToString());
            ViewBag.Pendidikan = helper.GetDropDownList("pendidikan", "pendidikan", query.PEND_TERAKHIR);
            ViewBag.StatusPegawai = helper.GetDropDownList("status_pegawai", "status", query.STATUS_KARYAWAN);
            ViewBag.SubLvl = helper.GetDropDownList("sublevel", "sublevel", query.SUB_BAND);

            return View();
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeToUpdate = db.karyawan.SingleOrDefault(m => m.NOABSEN == id);
            if (TryUpdateModel(employeeToUpdate))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(employeeToUpdate);
        }
    }
}
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
        private HRISContext db = new HRISContext();
        private HRISHelper helper = new HRISHelper();

        public ActionResult Index()
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

            var karyawan = new HRISHelper().GetPaginated(search, start.Value, length ?? 10, out totalRecords, out recordsFiltered);

            return JsonConvert.SerializeObject(karyawan);
        }

        public ActionResult Create()
        {
            ViewBag.CCTR = helper.GetDropDownList("cctr");
            ViewBag.Divisi = helper.GetDropDownList("divisi");
            ViewBag.Jabatan = helper.GetDropDownList("jabatan");
            ViewBag.LvlJabatan = helper.GetDropDownList("lvljabatan");
            ViewBag.Lokasi = helper.GetDropDownList("lokasi");
            ViewBag.Status = helper.GetDropDownList("status");
            ViewBag.SubLvlJabatan = helper.GetDropDownList("sublvljabatan");

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
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);

                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = db.karyawan.SingleOrDefault(m => m.karyawan_id == id);
            var employee = (from k in db.karyawan
                            where k.karyawan_id == id
                            select k).ToList();

            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.Karyawan = employee;
            ViewBag.CCTR = helper.GetDropDownList("cctr");
            ViewBag.Divisi = helper.GetDropDownList("divisi");
            ViewBag.Jabatan = helper.GetDropDownList("jabatan");
            ViewBag.LvlJabatan = helper.GetDropDownList("lvljabatan");
            ViewBag.Lokasi = helper.GetDropDownList("lokasi");
            ViewBag.Status = helper.GetDropDownList("status");
            ViewBag.SubLvlJabatan = helper.GetDropDownList("sublvljabatan");

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

            var employeeToUpdate = db.karyawan.SingleOrDefault(m => m.karyawan_id == id);

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
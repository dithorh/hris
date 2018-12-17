using hris.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Admin.Controllers
{
    public class PositionController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Admin/Position
        public ActionResult Index()
        {
            var pos = db.ref_gol_jabatan.ToList();

            return View(pos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(ref_gol_jabatan ref_Gol_Jabatan)
        {
            try
            {
                var check = db.ref_gol_jabatan.SingleOrDefault(m => m.gol_jabatan_id == ref_Gol_Jabatan.gol_jabatan_id);
                if (check == null)
                {
                    db.ref_gol_jabatan.Add(ref_Gol_Jabatan);
                    db.SaveChanges();
                    return Json("0", JsonRequestBehavior.AllowGet);
                }

                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("2", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ref_gol_jabatan ref_Gol_Jabatan = db.ref_gol_jabatan.Find(id);

            if (ref_Gol_Jabatan == null)
            {
                return HttpNotFound();
            }
            return View(ref_Gol_Jabatan);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public JsonResult EditPost(ref_gol_jabatan ref_Gol_Jabatan)
        {
            var pos = db.ref_gol_jabatan.Find(ref_Gol_Jabatan.gol_jabatan_id);
            pos.nama_jabatan = pos.nama_jabatan;

            if (TryUpdateModel(pos))
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
                ref_gol_jabatan ref_Gol_Jabatan = db.ref_gol_jabatan.Find(id);
                db.ref_gol_jabatan.Remove(ref_Gol_Jabatan);
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
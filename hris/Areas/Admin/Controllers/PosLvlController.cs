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
    public class PosLvlController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Admin/Position
        public ActionResult Index()
        {
            var posLvl = db.ref_lvl_jabatan.ToList();

            return View(posLvl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(ref_lvl_jabatan ref_Lvl_Jabatan)
        {
            try
            {
                var check = db.ref_lvl_jabatan.SingleOrDefault(m => m.lvl_jabatan_id == ref_Lvl_Jabatan.lvl_jabatan_id);
                if (check == null)
                {
                    db.ref_lvl_jabatan.Add(ref_Lvl_Jabatan);
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

            ref_lvl_jabatan ref_Gol_Jabatan = db.ref_lvl_jabatan.Find(id);

            if (ref_Gol_Jabatan == null)
            {
                return HttpNotFound();
            }
            return View(ref_Gol_Jabatan);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public JsonResult EditPost(ref_lvl_jabatan ref_Lvl_Jabatan)
        {
            var posLvl = db.ref_lvl_jabatan.Find(ref_Lvl_Jabatan.lvl_jabatan_id);
            posLvl.lvl_jabatan = posLvl.lvl_jabatan;

            if (TryUpdateModel(posLvl))
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
                ref_lvl_jabatan ref_lvl_jabatan = db.ref_lvl_jabatan.Find(id);
                db.ref_lvl_jabatan.Remove(ref_lvl_jabatan);
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
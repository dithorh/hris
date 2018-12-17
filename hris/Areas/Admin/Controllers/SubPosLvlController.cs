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
    public class SubPosLvlController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Admin/SubPosLvl
        public ActionResult Index()
        {
            var subPosLvl = db.ref_sub_lvl_jabatan.ToList();

            return View(subPosLvl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(ref_sub_lvl_jabatan ref_Sub_Lvl_Jabatan)
        {
            try
            {
                var check = db.ref_sub_lvl_jabatan.SingleOrDefault(m => m.sub_lvl_jabatan_id == ref_Sub_Lvl_Jabatan.sub_lvl_jabatan_id);
                if (check == null)
                {
                    db.ref_sub_lvl_jabatan.Add(ref_Sub_Lvl_Jabatan);
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

            ref_sub_lvl_jabatan ref_Sub_Lvl_Jabatan = db.ref_sub_lvl_jabatan.Find(id);

            if (ref_Sub_Lvl_Jabatan == null)
            {
                return HttpNotFound();
            }
            return View(ref_Sub_Lvl_Jabatan);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public JsonResult EditPost(ref_sub_lvl_jabatan ref_Sub_Lvl_Jabatan)
        {
            var subPosLvl = db.ref_sub_lvl_jabatan.Find(ref_Sub_Lvl_Jabatan.sub_lvl_jabatan_id);
            subPosLvl.sub_lvl_jabatan = subPosLvl.sub_lvl_jabatan;

            if (TryUpdateModel(subPosLvl))
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
                ref_sub_lvl_jabatan ref_Sub_Lvl_Jabatan = db.ref_sub_lvl_jabatan.Find(id);
                db.ref_sub_lvl_jabatan.Remove(ref_Sub_Lvl_Jabatan);
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
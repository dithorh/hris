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
    public class CCTRController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Admin/CCTR
        public ActionResult Index()
        {
            var cctr = db.ref_cctr.ToList();

            return View(cctr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(ref_cctr cctr)
        {
            try
            {
                var check = db.ref_cctr.SingleOrDefault(m => m.cctr_id == cctr.cctr_id);
                if (check == null)
                {
                    db.ref_cctr.Add(cctr);
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

            ref_cctr cctr = db.ref_cctr.Find(id);

            if (cctr == null)
            {
                return HttpNotFound();
            }
            return View(cctr);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public JsonResult EditPost(ref_cctr ref_Cctr)
        {
            var cctr = db.ref_cctr.Find(ref_Cctr.cctr_id);
            cctr.cctr = ref_Cctr.cctr;

            if (TryUpdateModel(cctr))
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
                ref_cctr ref_Cctr = db.ref_cctr.Find(id);
                db.ref_cctr.Remove(ref_Cctr);
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
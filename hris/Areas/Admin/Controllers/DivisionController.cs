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
    public class DivisionController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Admin/Division
        public ActionResult Index()
        {
            var division = db.ref_divisi.ToList();

            return View(division);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(ref_divisi _Divisi)
        {
            try
            {
                var check = db.ref_divisi.SingleOrDefault(m => m.nama_divisi == _Divisi.nama_divisi);
                if (check == null)
                {
                    db.ref_divisi.Add(_Divisi);
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

            ref_divisi ref_Divisi = db.ref_divisi.Find(id);

            if (ref_Divisi == null)
            {
                return HttpNotFound();
            }
            return View(ref_Divisi);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public JsonResult EditPost(ref_divisi ref_Divisi)
        {
            var divisi = db.ref_divisi.Find(ref_Divisi.divisi_id);
            divisi.nama_divisi = ref_Divisi.nama_divisi;

            if (TryUpdateModel(divisi))
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
                ref_divisi ref_Divisi = db.ref_divisi.Find(id);
                db.ref_divisi.Remove(ref_Divisi);
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
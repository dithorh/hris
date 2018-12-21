using hris.Handler;
using hris.Helpers;
using hris.Models;
using hris.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Admin.Controllers
{
    public class EmployeeHistoryController : Controller
    {
        private HRISContext db = new HRISContext();
        private HRISHelper helper = new HRISHelper();

        // GET: Admin/EmployeeHistory
        [SessionTimeout]
        public ActionResult Index(int? id)
        {
            var empHistory = from hk in db.hist_karyawan
                             join k in db.karyawan on hk.karyawan_id equals k.karyawan_id
                             join d in db.ref_divisi on hk.divisi_id equals d.divisi_id into divisiGroup
                             from dg in divisiGroup.DefaultIfEmpty()
                             join c in db.ref_cctr on hk.cctr_id equals c.cctr_id into cctrGroup
                             from cg in cctrGroup.DefaultIfEmpty()
                             join j in db.ref_gol_jabatan on hk.gol_jabatan_id equals j.gol_jabatan_id into jabatanGroup
                             from jg in jabatanGroup.DefaultIfEmpty()
                             join lj in db.ref_lvl_jabatan on hk.lvl_jabatan_id equals lj.lvl_jabatan_id into lvlJabatanGroup
                             from ljg in lvlJabatanGroup.DefaultIfEmpty()
                             join sj in db.ref_sub_lvl_jabatan on hk.sub_lvl_jabatan_id equals sj.sub_lvl_jabatan_id into sublvlJabatanGroup
                             from sjg in sublvlJabatanGroup.DefaultIfEmpty()
                             join sk in db.ref_status_karyawan on hk.status_karyawan_id equals sk.status_karyawan_id into statusGroup
                             from skg in statusGroup.DefaultIfEmpty()
                             join lk in db.ref_lokasi_kerja on hk.lokasi_kerja_id equals lk.lokasi_kerja_id into lokasiGroup
                             from lg in lokasiGroup.DefaultIfEmpty()
                             where k.karyawan_id == 16
                             select new EmployeeHistoryViewModel
                             {
                                 hist_karyawan_id = hk.hist_karyawan_id,
                                 divisi = (divisiGroup.Select(s => s.nama_divisi).FirstOrDefault() == null ? string.Empty : divisiGroup.Select(s => s.nama_divisi).FirstOrDefault()),
                                 cctr = (cctrGroup.Select(s => s.cctr).FirstOrDefault() == null ? string.Empty : cctrGroup.Select(s => s.cctr).FirstOrDefault()),
                                 jabatan = (jabatanGroup.Select(s => s.nama_jabatan).FirstOrDefault() == null ? string.Empty : jabatanGroup.Select(s => s.nama_jabatan).FirstOrDefault()),
                                 lvl_jabatan = (lvlJabatanGroup.Select(s => s.lvl_jabatan).FirstOrDefault() == null ? string.Empty : lvlJabatanGroup.Select(s => s.lvl_jabatan).FirstOrDefault()),
                                 sub_lvl_jabatan = (sublvlJabatanGroup.Select(s => s.sub_lvl_jabatan).FirstOrDefault() == null ? "\0" : sublvlJabatanGroup.Select(s => s.sub_lvl_jabatan).FirstOrDefault()),
                                 status_karyawan = (statusGroup.Select(s => s.status_karyawan).FirstOrDefault() == null ? string.Empty : statusGroup.Select(s => s.status_karyawan).FirstOrDefault()),
                                 lokasi_kerja = (lokasiGroup.Select(s => s.nama_lokasi).FirstOrDefault() == null ? string.Empty : lokasiGroup.Select(s => s.nama_lokasi).FirstOrDefault()),
                                 tgl_mulai = hk.tgl_mulai,
                                 tgl_selesai = hk.tgl_selesai,
                                 keterangan = hk.keterangan
                             };

            ViewBag.CCTR = helper.GetDropDownList("cctr");
            ViewBag.Divisi = helper.GetDropDownList("divisi");
            ViewBag.Jabatan = helper.GetDropDownList("jabatan");
            ViewBag.LvlJabatan = helper.GetDropDownList("lvljabatan");
            ViewBag.Lokasi = helper.GetDropDownList("lokasi");
            ViewBag.Status = helper.GetDropDownList("status");
            ViewBag.SubLvlJabatan = helper.GetDropDownList("sublvljabatan");

            return View(empHistory.ToList());
        }

        [SessionTimeout]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(hist_karyawan hist_Karyawan)
        {
            try
            {
                var user_id = Session["user_id"].ToString();
                hist_Karyawan.created_by = user_id;
                hist_Karyawan.date_created = DateTime.Now;

                db.hist_karyawan.Add(hist_Karyawan);
                db.SaveChanges();

                return Json("0", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("2", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
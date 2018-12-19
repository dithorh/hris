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

        // GET: Admin/EmployeeHistory
        public ActionResult Index(int? id)
        {
            var empHistory = db.hist_karyawan
                               .Join(db.karyawan, h => h.karyawan_id, k => (int?)(k.karyawan_id), (h, k) => new { h, k })
                               .Join(db.ref_divisi, d => d.h.divisi_id, h => h.divisi_id, (d, h) => new { d, h })
                               .Join(db.ref_cctr, c => c.d.h.cctr_id, h => h.cctr_id, (c, h) => new { c, h })
                               .Join(db.ref_gol_jabatan, j => j.c.d.h.gol_jabatan_id, h => h.gol_jabatan_id, (j, h) => new { j, h })
                               .Join(db.ref_lvl_jabatan, lj => lj.j.c.d.h.lvl_jabatan_id, h => h.lvl_jabatan_id, (lj, h) => new { lj, h })
                               .Join(db.ref_sub_lvl_jabatan, sj => sj.lj.j.c.d.h.sub_lvl_jabatan_id, h => h.sub_lvl_jabatan_id, (sj, h) => new { sj, h })
                               .Join(db.ref_status_karyawan, sk => sk.sj.lj.j.c.d.h.status_karyawan_id, h => h.status_karyawan_id, (sk, h) => new { sk, h })
                               .Join(db.ref_lokasi_kerja, lk => lk.sk.sj.lj.j.c.d.h.lokasi_kerja_id, h => h.lokasi_kerja_id, (lk, h) => new { lk, h })
                               .Where(w => w.lk.sk.sj.lj.j.c.d.h.karyawan_id == id)
                               .Select(s => new EmployeeHistoryViewModel
                               {
                                   hist_karyawan_id = s.lk.sk.sj.lj.j.c.d.h.hist_karyawan_id,
                                   divisi = s.lk.sk.sj.lj.j.c.h.nama_divisi,
                                   cctr = s.lk.sk.sj.lj.j.h.cctr,
                                   jabatan = s.lk.sk.sj.lj.h.nama_jabatan,
                                   lvl_jabatan = s.lk.sk.sj.h.lvl_jabatan,
                                   sub_lvl_jabatan = s.lk.sk.h.sub_lvl_jabatan,
                                   status_karyawan = s.lk.h.status_karyawan,
                                   lokasi_kerja = s.h.nama_lokasi,
                                   tgl_mulai = s.lk.sk.sj.lj.j.c.d.h.tgl_mulai,
                                   tgl_selesai = s.lk.sk.sj.lj.j.c.d.h.tgl_selesai,
                                   keterangan = s.lk.sk.sj.lj.j.c.d.h.keterangan
                               }).ToList();

            return View(empHistory);
        }
    }
}
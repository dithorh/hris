using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hris.Models;
using hris.DAL;
using hris.Handler;
using hris.ViewModels;

namespace hris.Areas.Employee.Controllers
{
    public class ProfileController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Employee/Profile
        [SessionTimeout]
        public ActionResult Index()
        {
            var user_id = Session["user_id"].ToString();
            var emp = db.karyawan.FirstOrDefault(m => m.user_id == user_id);

            return View(emp);
        }

        [SessionTimeout]
        public ActionResult Personal()
        {
            var user_id = Session["user_id"].ToString();
            var emp = db.karyawan.FirstOrDefault(m => m.user_id == user_id);

            return PartialView("~/Areas/Employee/Views/Profile/Personal.cshtml", emp);
        }

        [SessionTimeout]
        public ActionResult Employee()
        {
            var user_id = Session["user_id"].ToString();
            var emp = from k in db.karyawan
                       join hk in db.hist_karyawan on k.karyawan_id equals hk.karyawan_id
                       join d in db.ref_divisi on hk.divisi_id equals d.divisi_id
                       join lk in db.ref_lokasi_kerja on hk.lokasi_kerja_id equals lk.lokasi_kerja_id
                       join sk in db.ref_status_karyawan on hk.status_karyawan_id equals sk.status_karyawan_id
                       where k.user_id == user_id
                       select new EmployeeDetailViewModel
                       {
                           no_karyawan = k.no_karyawan,
                           inisial = k.inisial,
                           tgl_masuk = k.tgl_masuk,
                           divisi = lk.nama_lokasi,
                           job_title = hk.job_title,
                           status_karyawan = sk.status_karyawan,
                           lokasi_kerja = lk.nama_lokasi,
                           status_kerja = k.status_kerja,
                           keterangan = k.keterangan
                       };

            return PartialView("~/Areas/Employee/Views/Profile/Employee.cshtml", emp);
        }

        public ActionResult Bank()
        {
            var user_id = Session["user_id"].ToString();
            var emp = db.karyawan.FirstOrDefault(m => m.user_id == user_id);

            return PartialView("~/Areas/Employee/Views/Profile/Bank.cshtml", emp);
        }

        [SessionTimeout]
        public ActionResult Family()
        {
            var user_id = Session["user_id"].ToString();
            var empid = db.karyawan.SingleOrDefault(m => m.user_id == user_id).karyawan_id;
            var family = db.keluarga.FirstOrDefault(m => m.karyawan_id == empid);

            return PartialView("~/Areas/Employee/Views/Profile/Family.cshtml", family);
        }

        [SessionTimeout]
        public ActionResult Education()
        {
            var user_id = Session["user_id"].ToString();
            var empid = db.karyawan.SingleOrDefault(m => m.user_id == user_id).karyawan_id;
            var education = db.pendidikan.FirstOrDefault(m => m.karyawan_id == empid);

            return PartialView("~/Areas/Employee/Views/Profile/Education.cshtml", education);
        }

        [SessionTimeout]
        public ActionResult Job()
        {
            var user_id = Session["user_id"].ToString();
            var empid = db.karyawan.SingleOrDefault(m => m.user_id == user_id).karyawan_id;
            var job = db.pengalaman_kerja.FirstOrDefault(m => m.karyawan_id == empid);

            return PartialView("~/Areas/Employee/Views/Profile/Job.cshtml", job);
        }
    }
}
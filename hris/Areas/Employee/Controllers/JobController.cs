using hris.Handler;
using hris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class JobController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Employee/Job
        [SessionTimeout]
        public ActionResult Index()
        {
            var user_id = Session["user_id"].ToString();
            var empID = db.karyawan.SingleOrDefault(m => m.user_id == user_id).karyawan_id;
            var job = db.pengalaman_kerja.Find(empID);

            return View(job);
        }
    }
}
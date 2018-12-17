using hris.Handler;
using hris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class EducationController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Employee/Education
        [SessionTimeout]
        public ActionResult Index()
        {
            var user_id = Session["user_id"].ToString();
            var empID = db.karyawan.SingleOrDefault(m => m.user_id == user_id).karyawan_id;
            var education = db.pendidikan.Find(empID);

            return View(education);
        }
    }
}
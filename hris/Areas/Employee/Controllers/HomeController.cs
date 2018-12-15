using hris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Employee/Home
        public ActionResult Index()
        {
            var karyawan = db.karyawan.SingleOrDefault();

            return View(karyawan);
        }
    }
}
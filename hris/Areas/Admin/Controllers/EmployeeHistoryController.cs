using hris.Models;
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
            var empHistory = db.hist_karyawan.Find(id);

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Employee/Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}
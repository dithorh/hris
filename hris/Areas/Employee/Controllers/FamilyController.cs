using hris.Handler;
using hris.Models;
using System.Linq;
using System.Web.Mvc;

namespace hris.Areas.Employee.Controllers
{
    public class FamilyController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Employee/Family
        [SessionTimeout]
        public ActionResult Index()
        {
            var user_id = Session["user_id"].ToString();
            var empID = db.karyawan.SingleOrDefault(m => m.user_id == user_id).karyawan_id;
            var family = db.keluarga.Find(empID);

            return View(family);
        }
    }
}
using System.Web.Mvc;

namespace hris.Areas.Employee
{
    public class EmployeeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Employee";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Employee_default",
                "Employee/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "hris.Areas.Admin.Controllers" }
            );
        }
    }
}
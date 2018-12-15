using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hris.Models;
using hris.Helpers;
using System.Data.Entity;

namespace hris.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(user_login user_Login)
        {
            try
            {
                using (var db = new EmployeeContext())
                {
                    var user = db.user_login.FirstOrDefault(m => m.user_id == user_Login.user_id);

                    if (user != null)
                    {
                        var hashCode = user.vcode;
                        var encodingPasswordString = PasswordHashHelper.EncodePassword(user_Login.password, hashCode);
                        var query = db.user_login.FirstOrDefault(m => m.user_id == user_Login.user_id && m.password.Equals(encodingPasswordString));

                        if (query != null)
                        {
                            user.last_login = DateTime.Now;
                            db.user_login.Attach(user);
                            var entry = db.Entry(user);
                            entry.State = EntityState.Modified;

                            Session["user_id"] = user_Login.user_id;
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }

                        ViewBag.ErrorMsg = "Invalid username or password";
                        return View();
                    }

                    ViewBag.ErrorMsg = "Invalid username or password";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMsg = "Error :" + e.Message;
                return View();
            }
        }

        public ActionResult Register(user_login user_Login)
        {
            try
            {
                using (var db = new EmployeeContext())
                {
                    var chkUser = (from s in db.user_login where s.user_id == user_Login.user_id select s).FirstOrDefault();
                    if (chkUser == null)
                    {
                        var keyNew = PasswordHashHelper.GeneratePassword(10);
                        var pass = PasswordHashHelper.EncodePassword(user_Login.password, keyNew);
                        user_Login.password = pass;
                        user_Login.vcode = keyNew;
                        db.user_login.Add(user_Login);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("LogIn", "Login");
                    }
                    ViewBag.ErrorMessage = "User Allredy Exixts!!!!!!!!!!";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Some exception occured" + e;
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hris.Models;
using hris.Helpers;
using System.Data.Entity;
using System.Web.Security;
using hris.Handler;
using System.Data;

namespace hris.Controllers
{
    public class HomeController : Controller
    {
        private AsyncMethod async = new AsyncMethod();

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
                using (var db = new HRISContext())
                {
                    var user = db.user_login.FirstOrDefault(m => m.user_id == user_Login.user_id);

                    if (user != null)
                    {
                        var hashCode = user.vcode;
                        var encodingPasswordString = PasswordHashHelper.EncodePassword(user_Login.password, hashCode);
                        var query = db.karyawan
                            .Join(db.user_login, k => k.user_id, u => u.user_id, (k, u) => new { k, u })
                            .Where(x => x.u.user_id == user_Login.user_id && x.u.password.Equals(encodingPasswordString))
                            .Select(x => new { x.k.user_id, x.k.karyawan_id, x.u.status })
                            .FirstOrDefault();

                        if (query != null)
                        {
                            if (query.status)
                            {
                                Session["user_id"] = query.user_id;
                                Session["emp_id"] = query.karyawan_id;
                                var emp_id = (int)Session["emp_id"];
                                Session["pos"] = db.hist_karyawan
                                    .OrderByDescending(x => x.tgl_mulai)
                                    .Where(x => x.karyawan_id == emp_id)
                                    .Select(x => x.gol_jabatan_id)
                                    .Take(1)
                                    .FirstOrDefault();

                                async.UpdateWorkdaysAndAge(emp_id);

                                if (user.role == "superuser")
                                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                                else
                                    return RedirectToAction("Index", "Home", new { area = "Employee" });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Your account has not been activated. Please contact administrator.";
                                return View();
                            }
                        }

                        ViewBag.ErrorMsg = "Invalid username or password";
                        return View();
                    }

                    ViewBag.ErrorMsg = "Invalid username or password";
                    return View();
                }
            }
            catch (DataException e)
            {
                ViewBag.ErrorMsg = "Error :" + e.Message;
                return View();
            }
        }

        [SessionTimeout]
        public ActionResult LogOut()
        {
            var user_id = Session["user_id"].ToString();

            using (HRISContext db = new HRISContext())
            {
                var updateUserLogin = db.user_login.SingleOrDefault(m => m.user_id == user_id);
                updateUserLogin.last_login = DateTime.Now;
                db.user_login.Attach(updateUserLogin);
                db.Entry(updateUserLogin).Property(x => x.last_login).IsModified = true;
                db.SaveChanges();
            }

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(user_login user_Login)
        {
            try
            {
                using (var db = new HRISContext())
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
                    ViewBag.ErrorMessage = "User Already Exixts!";
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
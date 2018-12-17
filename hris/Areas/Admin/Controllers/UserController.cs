using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hris.DAL;
using hris.Helpers;
using hris.Models;

namespace hris.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private HRISContext db = new HRISContext();

        // GET: Admin/User
        public ActionResult Index()
        {
            var users = db.user_login.ToList();

            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user_login user_Login)
        {
            try
            {
                var check = (from s in db.user_login where s.user_id == user_Login.user_id select s).FirstOrDefault();
                if (check == null)
                {
                    var keyNew = PasswordHashHelper.GeneratePassword(10);
                    var pass = PasswordHashHelper.EncodePassword(user_Login.user_id + DateTime.Now.Year.ToString(), keyNew);
                    user_Login.password = pass;
                    user_Login.vcode = keyNew;
                    user_Login.date_created = DateTime.Now;

                    db.user_login.Add(user_Login);
                    db.SaveChanges();

                    ModelState.Clear();

                    return Json("0", JsonRequestBehavior.AllowGet);
                }

                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                return Json("2", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var user_Login = (from u in db.user_login
            //                  where u.user_id == id
            //                  select u).ToList();
            user_login user_Login = db.user_login.Find(id);

            if (user_Login == null)
            {
                return HttpNotFound();
            }

            return View(user_Login);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(user_login user_Login)
        {
            var user = db.user_login.Find(user_Login.user_id);
            user.role = user_Login.role;
            user.status = user_Login.status;
            user.date_modified = DateTime.Now;

            try
            {
                db.user_login.Attach(user);
                db.Entry(user).Property(x => x.role).IsModified = true;
                db.Entry(user).Property(x => x.status).IsModified = true;
                db.Entry(user).Property(x => x.date_modified).IsModified = true;
                db.SaveChanges();

                return Json("0", JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
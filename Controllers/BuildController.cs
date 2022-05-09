using registerapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace registerapp.Controllers
{
    public class BuildController : Controller
    {
        logindbEntities db = new logindbEntities();
        // GET: Build
        public ActionResult Index()
        {
            return View(db.logintables.ToList());
        }
        public ActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signin(logintable lt)
        {
            if(db.logintables.Any(x => x.Mail == lt.Mail))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                db.logintables.Add(lt);
                db.SaveChanges();

                Session["Id"] = lt.ID.ToString();
                Session["Username"] = lt.Mail.ToString();
                return RedirectToAction("Index", "Build");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(logintable lt)
        {
            var checkLogin = db.logintables.Where(x => x.Mail.Equals(lt.Mail) && x.Password.Equals(lt.Password)).FirstOrDefault();
            if (checkLogin != null)
            {

                Session["Id"] = lt.ID.ToString();
                Session["Username"] = lt.Mail.ToString();
                return RedirectToAction("create", "dinner");
            }
            else
            {
                ViewBag.Notification = "wrong username or password";
            }
            return View();
        }
    }
}
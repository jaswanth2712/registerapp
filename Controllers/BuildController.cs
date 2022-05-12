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
        dinnerrep d = new dinnerrep();
        loginrep r = new loginrep();
        public ActionResult ab(string id)//view list
            //after login
        {
            var data = d.FindUpcomingDinners(id);
            return View(data);
        }
        // GET: Build
        public ActionResult Index()//view list
        {
            return View(db.logintables.ToList());
        }
        public ActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signin(logintable lt)//register acc//create acc
        {
            if (db.logintables.Any(x => x.Mail == lt.Mail))
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
        public ActionResult login(logintable lt)//create view
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
        public ActionResult emp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult emp(logintable l)//createview
        {

            var adminname = "admin";
            var adminpass = "jas";

            if (adminname == l.Mail)
            {
                if (adminpass == l.Password )
                {
                    Session["Id"] = l.ID.ToString();
                    Session["Username"] = l.Mail.ToString();

                    return RedirectToAction("b", "Build");
                }
                else
                    return RedirectToAction("er", "Build");
            }
            else
                return RedirectToAction("err", "Build");
        }


        public ActionResult er()
        {
            return View();
        }


        public ActionResult err()
        {
            return View();
        }
        public ActionResult b()//empty-actionlink
        {
            return View();
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(logintable lt)//view create
        {

            logintable l = new logintable();

            l.Mail = lt.Mail;
            l.Password = lt.Password;
            r.Add(l);
            r.save();

            return RedirectToAction("create", "dinner");

        }

        public ActionResult delete(int id)//view delete
        {
            logintable l = r.GetLogintable(id);
            r.Delete(l);
            r.save();
            return RedirectToAction("Index");
        }
        public ActionResult update(int id)
        {
            var l = r.GetLogintable(id);
            return View(l);
        }
        [HttpPost]
        public ActionResult update(logintable lt)//view edit
        {
            logintable l = r.GetLogintable(lt.ID);
            l.ID = lt.ID;
            l.Mail = Convert.ToString(lt.Mail);
            l.Password = Convert.ToString(lt.Password);
            r.save();
            return View();
        }
        public ActionResult viewdetails(int id)//detailsview
        {
            logintable l = r.GetLogintable(id);

            return View(l);
        }
        public ActionResult Booking()
        {
            return View();
        }

    }
}
using registerapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace registerapp.Controllers
{
    public class bookingController : Controller
    {
        booktb b = new booktb();
        submitactionrep r = new submitactionrep();
        // GET: booking
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult book(string ss)
        {
            b.email = Session["username"].ToString();
            b.title = ss;
            b.dt = DateTime.Now;
            r.Add(b);
            r.save();
            return View();
        }
    }
}
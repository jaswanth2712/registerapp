using registerapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace registerapp.Controllers
{
    public class dinnerController : Controller
    {
        dinnerrep dp = new dinnerrep();
        // GET: dinner
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Dinner d)
        {

            Dinner dd = new Dinner();

            dd.DinnerID = d.DinnerID;
            dd.Title = d.Title;
            dd.EventDate = d.EventDate;
            dd.Description = d.Description;
            dd.HostedBy = d.HostedBy;
            dd.ContactPhone = d.ContactPhone;
            dd.Address = d.Address;
            dd.Country = d.Country;
            dd.Latitude = d.Latitude;
            dd.Longitude = d.Longitude;
            dp.Add(dd);

            // Persist Changes
            dp.Save();
            return View();
        }
        public ActionResult list()
        {

            return View(dp.FindAllDinners());

        }
        public ActionResult delete(int id)
        {
            dinnerrep dinnerRepository = new dinnerrep();

            // Retrieve specific dinner by its DinnerID
            Dinner dinner = dinnerRepository.GetDinner(id);


            // Mark dinner to be deleted
            dinnerRepository.Delete(dinner);

            // Persist changes
            dinnerRepository.Save();
            return RedirectToAction("list");
        }
        public ActionResult update(int id)
        {
            Dinner data = dp.GetDinner(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult update(Dinner d)
        {
            Dinner data = dp.GetDinner(d.DinnerID);

            data.Title = d.Title;
            data.Address = d.Address;
            data.ContactPhone = d.ContactPhone;
            data.Country = d.Country;
            data.Description = d.Description;
            data.EventDate = d.EventDate;
            data.HostedBy = d.HostedBy;
            data.Latitude = d.Latitude;
            data.Longitude = d.Longitude;
            dp.Save();
            return View();
        }
        public ActionResult viewdetails(int id)
        {
            Dinner data = dp.GetDinner(id);
            return View(data);

        }


    }
}
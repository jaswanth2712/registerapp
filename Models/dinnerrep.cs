using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace registerapp.Models
{
    public class dinnerrep
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinners;
        }

        public IQueryable<Dinner> FindUpcomingDinners(string name)
        {
            return from dinner in db.Dinners
                   where dinner.HostedBy==name
                   orderby dinner.EventDate
                   select dinner;
        }

        public Dinner GetDinner(int id)
        {
            return db.Dinners.SingleOrDefault(d => d.DinnerID == id);
        }



        public void Add(Dinner dinner)
        {
            db.Dinners.InsertOnSubmit(dinner);
        }

        public void Delete(Dinner dinner)
        {
            db.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
            db.Dinners.DeleteOnSubmit(dinner);
        }

        //
        // Persistence 

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
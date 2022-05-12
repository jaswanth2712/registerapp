using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace registerapp.Models
{
    public class submitactionrep
    {
        DataClasses2DataContext db = new DataClasses2DataContext();
        public IQueryable<booktb> FindAllDinners()
        {
            return db.booktbs;
        }

        public IQueryable<booktb> FindUpcomingDinners(string n)
        {
            return from dinner in db.booktbs
                   where dinner.email==n
                   orderby dinner.email
                   select dinner;
        }

        public booktb GetDinner(int di)
        {
            return db.booktbs.SingleOrDefault(d => d.id ==di);
        }



        public void Add(booktb dinner)
        {
            db.booktbs.InsertOnSubmit(dinner);
        }

        public void Delete(booktb dinner)
        {

            db.booktbs.DeleteOnSubmit(dinner);
        }
        public void save()
        {
            db.SubmitChanges();
        }
        //
    }
}
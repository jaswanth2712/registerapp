using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace registerapp.Models
{
    public class loginrep
    {
        logindbEntities d = new logindbEntities();
        public IQueryable<logintable> FindAlllogin()
        {
            return d.logintables;
        }
        public logintable GetLogintable(int id)
        {
            return d.logintables.SingleOrDefault(d => d.ID == id);
        }
        public logintable Getmail(string id)
        {
            return d.logintables.SingleOrDefault(d => d.Mail == id);
        }
        public void Add(logintable lt)
        {
            d.logintables.Add(lt);
        }
        public void Delete(logintable lt)
        {

            d.logintables.Remove(lt);
        }
        public void save()
        {
            d.SaveChanges();
        }
    }
}
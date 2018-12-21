using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SQLiteDateRepository : IRepository<Date> // unitofwork
    {
        private bool disposed = false;

        public SQLiteDateRepository(ExchangeOfficeContext db)
        {
            this.db = db;
        }

        public ExchangeOfficeContext db { get; set; }

        public IEnumerable<Date> GetList()
        {
            return db.Dates;
        }

        public Date Get(int id)
        {
            return db.Dates.Find(id);
        }

        public void Create(Date item)
        {
            ;
            foreach (var i in db.Customers)
            {
                i.DailyLimit = 1000M;
            }
            db.Dates.Add(item);
            db.SaveChanges();
        }

        public void Update(Date item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var date = db.Dates.Find(id);
            if (date != null)
            {
                db.Dates.Remove(date);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SQLiteExchangeRepository : IRepository<Exchange>
    {
        private ExchangeOfficeContext db;
        private bool disposed = false;

        public SQLiteExchangeRepository()
        {
            db = new ExchangeOfficeContext();
        }

        public IEnumerable<Exchange> GetList()
        {
            return db.Exchanges;
        }

        public Exchange Get(int id)
        {
            return db.Exchanges.Find(id);
        }

        public void Create(Exchange item)
        {
            db.Exchanges.Add(item);
        }

        public void Update(Exchange item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var exchange = db.Exchanges.Find(id);
            if (exchange != null)
            {
                db.Exchanges.Remove(exchange);
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
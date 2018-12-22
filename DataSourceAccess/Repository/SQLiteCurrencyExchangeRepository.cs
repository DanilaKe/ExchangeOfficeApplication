using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SQLiteCurrencyExchangeRepository : IRepository<CurrencyExchange>
    {
        private bool disposed = false;

        public SQLiteCurrencyExchangeRepository(ExchangeOfficeContext db)
        {
            this.db = db;
        }

        public ExchangeOfficeContext db { get; set; }

        public IEnumerable<CurrencyExchange> GetList()
        {
            return db.CurrencyExchanges;
        }

        public CurrencyExchange Get(int id)
        {
            return db.CurrencyExchanges.Find(id);
        }

        public void Create(CurrencyExchange item)
        {
            db.CurrencyExchanges.Add(item);
        }

        public void Update(CurrencyExchange item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var currencyExchange = db.CurrencyExchanges.Find(id);
            if (currencyExchange != null)
            {
                db.CurrencyExchanges.Remove(currencyExchange);
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
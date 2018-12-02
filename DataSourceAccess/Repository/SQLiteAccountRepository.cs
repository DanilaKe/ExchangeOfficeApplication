using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SQLiteAccountRepository : IRepository<Account>
    {
        private ExchangeOfficeContext db;
        private bool disposed = false;
        
        public SQLiteAccountRepository()
        {
            db = new ExchangeOfficeContext();
        }
        
        public IEnumerable<Account> GetList()
        {
            return db.Accounts;
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public void Create(Account item)
        {
            db.Accounts.Add(item);
        }

        public void Update(Account item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var account = db.Accounts.Find(id);
            if (account != null)
            {
                db.Accounts.Remove(account);
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
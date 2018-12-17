using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SQLiteCustomerRepository : IRepository<Customer>
    {
        private ExchangeOfficeContext db;
        private bool disposed = false;

        public SQLiteCustomerRepository()
        {
            db = new ExchangeOfficeContext();
        }
        public IEnumerable<Customer> GetList()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer item)
        {
            db.Customers.Add(item);
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var Customer = db.Customers.Find(id);
            if (Customer != null)
            {
                db.Customers.Remove(Customer);
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
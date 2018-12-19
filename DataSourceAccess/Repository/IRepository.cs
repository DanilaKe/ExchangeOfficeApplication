using System;
using System.Collections.Generic;

namespace DataSourceAccess
{
    public interface IRepository<T> : IDisposable 
        where T : class
    {
        ExchangeOfficeContext db { get; set; }
        IEnumerable<T> GetList(); 
        T Get(int id); 
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save(); 
    }
}
using System;
using System.Runtime.InteropServices.ComTypes;
using Ninject;

namespace DataSourceAccess
{
    public class UnitOfWork : IDisposable
    {
        private IKernel _kernel;
        private bool disposed = false;
        private ExchangeOfficeContext db = new ExchangeOfficeContext();
        private IRepository<Account> _repositoryAccount;
        private IRepository<CurrencyExchange> _repositoryCurrencyExchange;
        private IRepository<Customer> _repositoryCustomer;
        private IRepository<Date> _repositoryDate;
        private IRepository<Exchange> _repositoryExchange;

        public UnitOfWork(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IRepository<Account> Accounts
        {
            get
            {
                if (_repositoryAccount == null)
                {
                    _repositoryAccount = _kernel.Get<IRepository<Account>>();
                    _repositoryAccount.db = db;
                }

                return _repositoryAccount;
            }
        }

        public IRepository<CurrencyExchange> CurrencyExchanges
        {
            get
            {
                if (_repositoryCurrencyExchange == null)
                {
                    _repositoryCurrencyExchange = _kernel.Get<IRepository<CurrencyExchange>>();
                    _repositoryCurrencyExchange.db = db;
                }
                
                return _repositoryCurrencyExchange;
            }
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (_repositoryCustomer == null)
                {
                    _repositoryCustomer = _kernel.Get<IRepository<Customer>>();
                    _repositoryCustomer.db = db;
                }
                
                return _repositoryCustomer;
            }
        }

        public IRepository<Date> Dates
        {
            get
            {
                if (_repositoryDate == null)
                {
                    _repositoryDate = _kernel.Get<IRepository<Date>>();
                    _repositoryDate.db = db;
                }
                
                return _repositoryDate;
            }
        }

        public IRepository<Exchange> Exchanges
        {
            get
            {
                if (_repositoryExchange == null)
                {
                    _repositoryExchange = _kernel.Get<IRepository<Exchange>>();
                    _repositoryExchange.db = db;
                }

                return _repositoryExchange;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
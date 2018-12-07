using System;
using DataSourceAccess;
using ExchangeOffice.Service;
using Ninject;

namespace ExchangeOffice
{
    public class ExchangeOffice : ExecutorCommands, IEventsCommands
    {
        private StandardKernel _kernel;

        public ExchangeOffice()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IRepository<DataSourceAccess.Account>>().To<SQLiteAccountRepository>();
            _kernel.Bind<IRepository<DataSourceAccess.Custumer>>().To<SQLiteCustumerRepository>();
            _kernel.Bind<IRepository<DataSourceAccess.CurrencyExchange>>().To<SQLiteCurrencyExchangeRepository>();
            _kernel.Bind<IRepository<Date>>().To<SQLiteDateRepository>();
        }

        public void CallEvent(ServiceEventArgs e, ServiceStateHandler handler)
        {
            if (handler != null && e!=null)
                handler(this, e);
        }

       public event ServiceStateHandler LoginEvent;
       public event ServiceStateHandler ExchangeEvent;
       internal override void Exchange(string name, Currency TargetCurrency, Currency ContributedCurrency, decimal amount)
       {
           var service = new ExchangeService(_kernel,name, ContributedCurrency,TargetCurrency, amount);
           service.Invoke();
       }

       internal override void ViewingHistory(int customerID)
       {
           throw new NotImplementedException();
       }

       internal override void Login(string login, string password,bool adminFlag)
       {
           var service = new LoginService(_kernel,login,password,adminFlag);
           CallEvent(service.Invoke(),LoginEvent);
       }

       internal override void CurrencyExchangeUpdate(Currency TargetCurrency, Currency ContributedCurrency, decimal newPurchaseRate,
           decimal newSaleRate)
       {
           throw new NotImplementedException();
       }

       internal override void GetLog()
       {
           throw new NotImplementedException();
       }
    }
}
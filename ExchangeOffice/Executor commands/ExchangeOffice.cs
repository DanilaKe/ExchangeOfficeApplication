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
        }

        public void CallEvent(ServiceEventArgs e, ServiceStateHandler handler)
        {
            if (handler != null && e!=null)
                handler(this, e);
        }

        public event ServiceStateHandler LoginEvent;
       internal override void Exchange(int customerID, Currency TargetCurrency, Currency ContributedCurrency, decimal amount)
       {
           throw new NotImplementedException();
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

       internal override void CurrenceExchangeUpdate(Currency TargetCurrency, Currency ContributedCurrency, decimal newPurchaseRate,
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
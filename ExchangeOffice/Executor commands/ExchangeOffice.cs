using System;
using DataSourceAccess;
using ExchangeOffice.Service;
using Ninject;

namespace ExchangeOffice
{
    public class ExchangeOffice : ExecutorCommands
    {
        private StandardKernel _kernel; // создать отдельные исполнители для различных команд( скорее всего отдельные исполнители для разных окон, но пока хз).

        public ExchangeOffice()
        {
            _kernel = new StandardKernel(); // попробывать раздавать кернелы через встроенные функции нинджекта, а не передовать в конструктор.(или как-то так)
            _kernel.Bind<IRepository<DataSourceAccess.Account>>().To<SQLiteAccountRepository>(); // возможно попробывать заюхать паттерн фасад.
            _kernel.Bind<IRepository<DataSourceAccess.Customer>>().To<SQLiteCustomerRepository>();
            _kernel.Bind<IRepository<DataSourceAccess.CurrencyExchange>>().To<SQLiteCurrencyExchangeRepository>();
            _kernel.Bind<IRepository<Date>>().To<SQLiteDateRepository>();
        }

        internal override void CallEvent(IServiceEventArgs e, Action<object,IServiceEventArgs> handler)
        {
            if (handler != null && e!=null)
                handler(this, e);
        }

       public Action<object,IServiceEventArgs> LoginEvent;
       public Action<object,IServiceEventArgs> ExchangeEvent;
       internal override void Exchange(string name, Currency TargetCurrency, Currency ContributedCurrency, decimal amount)
       {
           var service = new ExchangeService(_kernel,name, ContributedCurrency,TargetCurrency, amount);
           CallEvent(service.Invoke(),base.ExchangeEvent);
       }

       internal override void ViewingHistory(int customerID)
       {
           throw new NotImplementedException();
       }

       internal override void Login(string login, string password,bool adminFlag)
       {
           var service = new LoginService(_kernel,login,password,adminFlag);
           CallEvent(service.Invoke(),base.LoginEvent);
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
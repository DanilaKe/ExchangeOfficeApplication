using System;
using DataSourceAccess;
using ExchangeOffice.Service;
using Ninject;

namespace ExchangeOffice
{
    public class ExchangeOffice : ExecutorCommands
    {
        private StandardKernel _kernel;

        public ExchangeOffice()
        {
            var registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);
        }
        internal override void CallEvent<T>(ServiceEventArgs<T> e, Action<object,ServiceEventArgs<T>> handler)
        {
            if (handler != null && e!=null)
                handler(this, e);
        }
        
       internal override void Exchange(string name, Currency TargetCurrency, Currency ContributedCurrency, decimal amount)
       {
           var service = _kernel.Get<IExchangeService>();
           service.Name = name;
           service.TargetCurrency = TargetCurrency;
           service.ContributedCurrency = ContributedCurrency;
           service.ContributedAmount = amount;
           CallEvent(service.Invoke(),ExchangeEvent);
       }
       
       internal override void GetCurrencyRate()
       {
           var service = _kernel.Get<IViewExchangeRateService>();
           CallEvent(service.Invoke(),CurrencyRateEvent);
       }

       internal override void ViewingHistory()
       {
           var service = _kernel.Get<IHistoryService>();
           CallEvent(service.Invoke(),HistoryEvent);
       }

       internal override void Login(string login, string password,bool adminFlag)
       {
           var service = _kernel.Get<ILoginService>();
           service.Login = login;
           service.Password = password;
           service.AdminFlag = adminFlag;
           CallEvent(service.Invoke(),LoginEvent);
       }

       internal override void CurrencyExchangeUpdate(Currency TargetCurrency, Currency ContributedCurrency, decimal Rate)
       {
           var service = _kernel.Get<ICurrencyExchangeUpdateService>();
           service.Rate = Rate;
           service.TargetCurrency = TargetCurrency;
           service.ContributedCurrency = ContributedCurrency;
           CallEvent(service.Invoke(),UpdateRateEvent);
       }
    }
}
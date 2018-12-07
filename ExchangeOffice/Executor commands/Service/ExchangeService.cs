using System.Collections;
using System.ComponentModel.Design;
using System.Linq;
using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    internal class ExchangeService : Service
    {
        private IKernel _kernel;
        string Name { get;}
        Currency ContributedCurrency { get; }
        Currency TargetCurrency { get; }
        decimal ContributedAmount { get;  }
        private IRepository<Custumer> db;
        public ExchangeService(IKernel kernel, string name, Currency contributedCurrency, Currency targetCurrency, decimal contributedAmount)
        {
            _kernel = kernel;
            Name = name;
            ContributedCurrency = contributedCurrency;
            TargetCurrency = targetCurrency;
            ContributedAmount = contributedAmount;
            db = _kernel.Get<IRepository<Custumer>>();
        }
        internal override ServiceEventArgs Invoke()
        {
            var customer = GetCustomer();
            var rate = _kernel.Get<IRepository<CurrencyExchange>>().GetList().FirstOrDefault(x =>
                x.ContributedCurrency == ContributedCurrency &&
                x.TargetCurrency == TargetCurrency);
            if (customer.DailyLimit >= ContributedAmount)
            {
                decimal IssuedAmount = ContributedAmount * rate.Rate;
                customer.HistoryOfExchanges.Add(new Exchange()
                {
                    ContributedAmount = ContributedAmount,
                    CurrencyExchangeId = rate.CurrencyExchangeId,
                    IssuedAmount = IssuedAmount,
                    CustumerId = customer.CustumerId,
                    Date = new Date()
                });
                db.Save();
            }
            
            return null;
        }

        private Custumer GetCustomer()
        {
            if (!db.GetList().Select(x => x.Name).Any(x => x == Name))
            {
                db.Create(new Custumer() {Name = Name, DailyLimit = 1000});
                db.Save();
            }

            return db.GetList().Select(x => x).FirstOrDefault(x => x.Name == Name);
        }
    }
}
using System;
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
            var rateToUSD = GetRateToUSD();
            if (customer.DailyLimit >= ContributedAmount*rateToUSD)
            {
                customer.DailyLimit -= ContributedAmount * rateToUSD;
                decimal IssuedAmount = ContributedAmount * rate.Rate;
                customer.HistoryOfExchanges.Add(new Exchange()
                {
                    ContributedAmount = ContributedAmount,
                    CurrencyExchangeId = rate.CurrencyExchangeId,
                    IssuedAmount = IssuedAmount,
                    CustumerId = customer.CustumerId,
                    DateId = GetDate()
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

        private decimal GetRateToUSD()
        {
            return ContributedCurrency == TargetCurrency? 
                1 : _kernel.Get<IRepository<CurrencyExchange>>().GetList().FirstOrDefault(x =>
                    x.ContributedCurrency == ContributedCurrency &&
                    x.TargetCurrency == (Currency) 3).Rate;
        }

        private int GetDate()
        {
            var db = _kernel.Get<IRepository<Date>>();
            bool newday;
            if (db.GetList()?.Count() != 0)
            {
                newday = !Equals(db.GetList().Last().DateTime, DateTime.Today);
            }
            else
            {
                newday = true;
            }
            if (newday)
            {
                db.Create(new Date(){DateTime = DateTime.Today});
                db.Save();
                UpdateDailyLimit();
            }

            return db.GetList().Last().DateId;
        }

        private void UpdateDailyLimit()
        {
            var db = _kernel.Get<IRepository<Custumer>>();
            foreach (var i in db.GetList())
            {
                i.DailyLimit = 1000;
            }
            db.Save();
        }
    }
}
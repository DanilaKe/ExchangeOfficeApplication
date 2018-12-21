using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    internal class ExchangeService : IExchangeService
    {
        private IKernel _kernel;
        public string Name { get; set; }
        public Currency ContributedCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        public decimal ContributedAmount { get; set; }
        public ExchangeService(IKernel kernel)
        {
            _kernel = kernel;
        }
        public ServiceEventArgs<Exchange> Invoke()
        {
            ServiceEventArgs<Exchange> e;
            var customer = GetCustomer();
            var rate = _kernel.Get<UnitOfWork>().CurrencyExchanges.GetList().Last(x => x.ContributedCurrency == ContributedCurrency &&
                                                                                       x.TargetCurrency == TargetCurrency);
            var rateToUSD = GetRateToUSD();
            if (customer.DailyLimit >= ContributedAmount*rateToUSD)
            {
                customer.DailyLimit -= ContributedAmount * rateToUSD;
                var IssuedAmount = ContributedAmount * rate.Rate;
                customer.HistoryOfExchanges.Add(new Exchange()
                {
                    ContributedAmount = ContributedAmount,
                    CurrencyExchangeId = rate.CurrencyExchangeId,
                    IssuedAmount = IssuedAmount,
                    CustomerId = customer.CustomerId,
                    DateId = GetDate()
                });
                _kernel.Get<UnitOfWork>().Save();
                e = new ServiceEventArgs<Exchange>()
                {
                    Status = true,
                    Result = new List<Exchange>(){customer.HistoryOfExchanges.Last()},
                    Message = "Successful"
                };
            }
            else
            {
                e = new ServiceEventArgs<Exchange>()
                {
                    Status = false,Result = new List<Exchange>(), Message = "Exceeded daily limit."
                };
            }
            
            return e;
        }

        private Customer GetCustomer()
        {
            var db = _kernel.Get<UnitOfWork>().Customers;
            if (!db.GetList().Select(x => x.Name).Any(x => x == Name))
            {
                db.Create(new Customer() {Name = Name, DailyLimit = 1000});
                db.Save();
            }

            return db.GetList().Select(x => x).FirstOrDefault(x => x.Name == Name);
        }

        private decimal GetRateToUSD()
        {
            return ContributedCurrency == TargetCurrency? 
                1M : _kernel.Get<UnitOfWork>().CurrencyExchanges.GetList().FirstOrDefault(x =>
                    x.ContributedCurrency == ContributedCurrency &&
                    x.TargetCurrency == (Currency) 3).Rate;
        }

        private int GetDate()
        {
            var db = _kernel.Get<UnitOfWork>().Dates;
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
            var db = _kernel.Get<UnitOfWork>().Customers;
            foreach (var i in db.GetList())
            {
                i.DailyLimit = 1000M;
            }
            db.Save();
        }
    }
}
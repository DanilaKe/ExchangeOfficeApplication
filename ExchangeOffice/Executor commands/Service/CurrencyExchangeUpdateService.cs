using System.Collections.Generic;
using System.Linq;
using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    internal class CurrencyExchangeUpdateService : ICurrencyExchangeUpdateService
    {
        private IKernel _kernel;
        public Currency ContributedCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        public decimal Rate { get; set; }

        public  CurrencyExchangeUpdateService(IKernel kernel)
        {
            _kernel = kernel;
        }
        public ServiceEventArgs<CurrencyExchange> Invoke()
        {
            var newCurrencyExchange = new CurrencyExchange()
            {
                ContributedCurrency = ContributedCurrency,
                TargetCurrency = TargetCurrency,
                DateId = _kernel.Get<UnitOfWork>().Dates.GetList().Last().DateId,
                Rate = Rate
            };
            _kernel.Get<UnitOfWork>().CurrencyExchanges.Create(newCurrencyExchange);
            _kernel.Get<UnitOfWork>().Save();
            return new ServiceEventArgs<CurrencyExchange>()
            {
                Status = true,
                Message = "Successful.",
                Result = new List<CurrencyExchange>(){newCurrencyExchange}
            };
        }
    }
}
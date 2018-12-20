using System;
using System.Linq;
using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    public class ViewExchangeRateService : IViewExchangeRateService
    {
        private IKernel _kernel;

        public ViewExchangeRateService(IKernel kernel)
        {
            _kernel = kernel;
            
        }
        public IServiceEventArgs Invoke()
        {
            IServiceEventArgs e;
            if (_kernel.Get<UnitOfWork>().Dates.GetList().Last().DateTime != DateTime.Today)
            {
                _kernel.Get<UnitOfWork>().Dates.Create(new Date(){DateTime = DateTime.Today});
                _kernel.Get<CurrencyRatePage>().UpdateCurrencyExchange();
                _kernel.Get<UnitOfWork>().Save();
            }
            e = new ViewExchangeRateServiceEventArgs()
            {
                Status = true,
                CurrencyExchanges = _kernel.Get<UnitOfWork>().CurrencyExchanges.GetList().Last().Date.CurrencyExchanges.ToList(),
                Message = "Successful."
            };
            return e;
        }
    }
}
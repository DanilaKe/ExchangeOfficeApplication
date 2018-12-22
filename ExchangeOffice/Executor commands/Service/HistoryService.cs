using System;
using System.Linq;
using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    internal class HistoryService : IHistoryService
    {
        private IKernel _kernel;

        public HistoryService(IKernel kernel)
        {
            _kernel = kernel;
            
        }
        public ServiceEventArgs<Exchange> Invoke()
        {
            ServiceEventArgs<Exchange> e;
            e = new ServiceEventArgs<Exchange>()
            {
                Status = true,
                Message = "Successful",
                Result = _kernel.Get<UnitOfWork>().Exchanges.GetList().ToList()
            };
            return e;
        }
    }
}
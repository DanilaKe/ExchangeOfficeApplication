using DataSourceAccess;
using ExchangeOffice.Service;
using Ninject.Modules;

namespace ExchangeOffice
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<DataSourceAccess.Account>>().To<SQLiteAccountRepository>(); 
            Bind<IRepository<Customer>>().To<SQLiteCustomerRepository>();
            Bind<IRepository<Exchange>>().To<SQLiteExchangeRepository>();
            Bind<IRepository<CurrencyExchange>>().To<SQLiteCurrencyExchangeRepository>();
            Bind<IRepository<Date>>().To<SQLiteDateRepository>();
            Bind<IExchangeService>().To<ExchangeService>().InSingletonScope();
            Bind<IHistoryService>().To<HistoryService>().InSingletonScope();
            Bind<ILoginService>().To<LoginService>().InSingletonScope();
            Bind<IViewExchangeRateService>().To<ViewExchangeRateService>().InSingletonScope();
            Bind<ICurrencyExchangeUpdateService>().To<CurrencyExchangeUpdateService>().InSingletonScope();
            Bind<UnitOfWork>().ToSelf().InSingletonScope();
            Bind<CurrencyRatePage>().ToSelf().InSingletonScope();
        }
    }
}
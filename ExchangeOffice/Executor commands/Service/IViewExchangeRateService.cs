using DataSourceAccess;

namespace ExchangeOffice.Service
{
    public interface IViewExchangeRateService
    {
        ServiceEventArgs<CurrencyExchange> Invoke();
    }
}
using DataSourceAccess;

namespace ExchangeOffice.Service
{
    public interface ICurrencyExchangeUpdateService
    {
        Currency ContributedCurrency { get; set; }
        Currency TargetCurrency { get; set; }
        decimal Rate { get; set; }   
        ServiceEventArgs<CurrencyExchange> Invoke(); 
    }
}
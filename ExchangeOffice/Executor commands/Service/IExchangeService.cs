using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    public interface IExchangeService
    {
        string Name { get; set; }
        Currency ContributedCurrency { get; set; }
        Currency TargetCurrency { get; set; }
        decimal ContributedAmount { get; set; }   
        IServiceEventArgs Invoke();       
    }
}
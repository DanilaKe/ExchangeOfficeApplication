using DataSourceAccess;

namespace ExchangeOffice.Service
{
    public interface IHistoryService
    {
        ServiceEventArgs<Exchange> Invoke();
    }
}
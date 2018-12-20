using System.Collections.Generic;
using DataSourceAccess;

namespace ExchangeOffice
{
    public class ViewExchangeRateServiceEventArgs : IServiceEventArgs
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public List<CurrencyExchange> CurrencyExchanges{ get; set; }
    }
}
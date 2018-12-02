using System.Collections.Generic;

namespace DataSourceAccess
{
    public class CurrencyExchange
    {
        public int CurrencyExchangeId { get; set; }
        public Currency ContributedCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        public decimal Rate { get; set; }
        public bool ActualStatus { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
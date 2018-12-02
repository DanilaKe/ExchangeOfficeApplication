using System.Collections.Generic;

namespace DataSourceAccess
{
    public class CurrencyExchange
    {
        public int CurrencyPairId { get; set; }
        public Currency ContributedCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        public decimal Rate { get; set; }
        public bool ActualStatus { get; set; }
        public ICollection<HistoryOfExchanges> HistoryOfExchanges { get; set; }
    }
}
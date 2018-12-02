namespace DataSourceAccess
{
    public class HistoryOfExchanges
    {
        public int ExchangeId { get; set; }
        public Date Date { get; set; }
        public int CurrencyPairId { get; set; }
        public CurrencyExchange CurrencyExchange { get; set; } 
        public decimal ContributedAmount { get; set; }
        public decimal IssuedAmount { get; set; }
        public int CustumerId { get; set; }
        public Custumer Custumer { get; set; }
    }
}

namespace DataSourceAccess
{
    public class Exchange
    {
        public int ExchangeId { get; set; }
        public Date Date { get; set; }
        public int CurrencyExchangeId { get; set; }
        public CurrencyExchange CurrencyExchange { get; set; } 
        public decimal ContributedAmount { get; set; }
        public decimal IssuedAmount { get; set; }
        public int CustumerId { get; set; }
        public Custumer Custumer { get; set; }
    }
}

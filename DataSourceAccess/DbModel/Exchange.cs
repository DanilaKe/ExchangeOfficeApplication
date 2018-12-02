using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Exchange
    {
        [Key] public int ExchangeId { get; set; }
        [Required] public Date Date { get; set; }
        public int CurrencyExchangeId { get; set; }
        [Required] public CurrencyExchange CurrencyExchange { get; set; } 
        [Required] public decimal ContributedAmount { get; set; }
        [Required] public decimal IssuedAmount { get; set; }
        public int CustumerId { get; set; }
        public Custumer Custumer { get; set; }
    }
}

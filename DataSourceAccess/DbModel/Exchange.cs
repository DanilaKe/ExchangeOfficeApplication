using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Exchange
    {
        [Key] public int ExchangeId { get; set; }
        public int? DateId { get; set; }
        [Required] public Date Date { get; set; }
        public int? CurrencyExchangeId { get; set; }
        [Required] public CurrencyExchange CurrencyExchange { get; set; } 
        [Required] public decimal ContributedAmount { get; set; }
        [Required] public decimal IssuedAmount { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

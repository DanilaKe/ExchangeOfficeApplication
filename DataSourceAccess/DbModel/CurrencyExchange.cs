using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class CurrencyExchange
    {
        [Key] public int CurrencyExchangeId { get; set; }
        [Range(1,4), Required] public Currency ContributedCurrency { get; set; }
        [Range(1,4), Required] public Currency TargetCurrency { get; set; }
        [Required] public decimal Rate { get; set; }
        [Range(0,1), Required]public bool ActualStatus { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
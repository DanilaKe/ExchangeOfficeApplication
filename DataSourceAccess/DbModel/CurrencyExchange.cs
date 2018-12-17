using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSourceAccess
{
    public class CurrencyExchange
    {
        [Key] public int CurrencyExchangeId { get; set; }
        
        [Range(1, 4), Required] public int ContributedCurrencyValue { get; set; }
        
        [Range(1, 4), NotMapped]
        public Currency ContributedCurrency
        {
            get => (Currency) ContributedCurrencyValue;
            set => ContributedCurrencyValue = (int) value;
        }
        [Range(1, 4), Required] public int TargetCurrencyValue { get; set; }
        
        [Range(1, 4), NotMapped]
        public Currency TargetCurrency
        {
            get => (Currency) TargetCurrencyValue;
            set => TargetCurrencyValue = (int) value;
        }
        
        [Required] public decimal Rate { get; set; }
        public int? DateId { get; set; }
        public Date Date { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
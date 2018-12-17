using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Customer
    {
        public Customer()
        {
            HistoryOfExchanges = new List<Exchange>();
        }
        
        [Key]public int CustomerId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public decimal DailyLimit { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Custumer
    {
        [Key]public int CustumerId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public decimal DailyLimit { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
using System.Collections.Generic;

namespace DataSourceAccess
{
    public class Custumer
    {
        public int CustumerId { get; set; }
        public string Name { get; set; }
        public decimal DailyLimit { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
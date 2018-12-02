using System;
using System.Collections.Generic;

namespace DataSourceAccess
{
    public class Date
    {
        public int DateId { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
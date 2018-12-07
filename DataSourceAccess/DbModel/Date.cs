using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Date
    {
        public Date()
        {
            HistoryOfExchanges = new List<Exchange>();
        }
        [Key]public int DateId { get; set; }
        [Required]public DateTime DateTime { get; set; }
        public ICollection<Exchange> HistoryOfExchanges { get; set; }
    }
}
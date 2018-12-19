using DataSourceAccess;

namespace ExchangeOffice
{

    public class ExchangeServiceEventArgs : IServiceEventArgs
    {
        public Exchange Exchange { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
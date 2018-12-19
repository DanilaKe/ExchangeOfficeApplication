namespace ExchangeOffice
{
    public class LoginServiceEventArgs : IServiceEventArgs
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public DataSourceAccess.Account Account { get; set; }
    }
}
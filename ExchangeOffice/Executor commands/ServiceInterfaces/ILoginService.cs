namespace ExchangeOffice.Service
{
    public interface ILoginService
    {
        string Login { get; set; }
        string Password { get; set; }
        bool AdminFlag { get; set; }
        ServiceEventArgs<DataSourceAccess.Account> Invoke();
    }
}
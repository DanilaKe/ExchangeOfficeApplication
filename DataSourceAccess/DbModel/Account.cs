namespace DataSourceAccess
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;


namespace DataSourceAccess
{
    public class ExchangeOfficeContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./DataSourceAccess/ExchangeOffice.db");
        }
    }
}
using DataSourceAccess;

namespace ExchangeOffice
{
    public class CurrencyExchangeUpdateCommand : Command
    {
        Currency ContributedCurrency { get; }
        Currency TargetCurrency { get; }
        decimal Rate { get;  }
        
        public CurrencyExchangeUpdateCommand(ExecutorCommands executorCommands, Currency contributedCurrency, 
            Currency targetCurrency, decimal rate) : base(executorCommands)
        {
            ContributedCurrency = contributedCurrency;
            TargetCurrency = targetCurrency;
            Rate = rate;
        }

        internal override void Execute()
        {
            _executorCommands.CurrencyExchangeUpdate(TargetCurrency,ContributedCurrency,Rate);
        }
    }
}
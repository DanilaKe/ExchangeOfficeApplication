using DataSourceAccess;

namespace ExchangeOffice
{
    public class ExchangeCommand : Command
    {
        string Name { get;}
        Currency ContributedCurrency { get; }
        Currency TargetCurrency { get; }
        decimal ContributedAmount { get;  }

        public ExchangeCommand(ExecutorCommands executorCommands, string name, Currency contributedCurrency, 
            Currency targetCurrency, decimal contributedAmount) : base(executorCommands)
        {
            Name = name;
            ContributedCurrency = contributedCurrency;
            TargetCurrency = targetCurrency;
            ContributedAmount = contributedAmount;
        }


        internal override void Execute() =>
            _executorCommands.Exchange(Name, TargetCurrency, ContributedCurrency, ContributedAmount);
    }
}
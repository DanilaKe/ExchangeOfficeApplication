namespace ExchangeOffice
{
    public class ViewingTodayRateCommand : Command
    {
        
        public ViewingTodayRateCommand(ExecutorCommands executorCommands) : base(executorCommands) { }

        internal override void Execute()
        {
            _executorCommands.GetCurrencyRate();
        }
    }
}
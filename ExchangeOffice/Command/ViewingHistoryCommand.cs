namespace ExchangeOffice
{
    public class ViewingHistoryCommand : Command
    {
        public ViewingHistoryCommand(ExecutorCommands executorCommands) : base(executorCommands)
        {
        }

        internal override void Execute()
        {
            _executorCommands.ViewingHistory();
        }
    }
}
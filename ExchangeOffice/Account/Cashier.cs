namespace ExchangeOffice
{
    public sealed class Cashier : Account
    {
        internal Cashier()
        {
            Account.Instance = this;
        }
        public override bool SendCommand(Command command)
        {
            if (command is ExchangeCommand || command is ViewingTodayRateCommand || command is ViewingHistoryCommand)
            {
                command.Execute();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
namespace ExchangeOffice
{
    public sealed class Administrator : Account
    {
        internal Administrator()
        {
            Account.Instance = this;
        }
        public override bool SendCommand(Command command)
        {
            if (command is CurrencyExchangeUpdateCommand)
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
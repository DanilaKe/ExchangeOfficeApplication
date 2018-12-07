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
            if (command is ExchangeCommand)
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
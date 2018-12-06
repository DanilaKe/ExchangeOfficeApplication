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
            throw new System.NotImplementedException();
        }
    }
}
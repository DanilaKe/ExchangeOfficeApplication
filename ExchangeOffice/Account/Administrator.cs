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
            throw new System.NotImplementedException();
        }
    }
}
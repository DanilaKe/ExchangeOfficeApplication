namespace ExchangeOffice
{
    public sealed class UnauthenticatedUser : Account
    {
        public UnauthenticatedUser()
        {
            Account.Instance = this;
        }
        public override bool SendCommand(Command command)
        {
            if (command is LoginCommand)
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
namespace ExchangeOffice
{
    public class UnauthenticatedUser : IAccount
    {
        public bool SendCommand(Command command)
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
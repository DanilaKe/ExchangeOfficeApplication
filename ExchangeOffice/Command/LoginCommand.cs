namespace ExchangeOffice
{
    public class LoginCommand : Command
    {
        private string login;
        private string password;
        public LoginCommand(ExecutorCommands executorCommands,string login, string password) : base(executorCommands)
        {
            this.login = login;
            this.password = password;
        }
        internal override void Execute()
        {
            _executorCommands.Login(login,password);
        }
    }
}
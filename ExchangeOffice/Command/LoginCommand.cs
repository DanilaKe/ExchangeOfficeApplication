namespace ExchangeOffice
{
    public class LoginCommand : Command
    {
        private string login;
        private string password;
        private bool adminFlag;
        public LoginCommand(ExecutorCommands executorCommands,string login, string password,bool adminFlag) : base(executorCommands)
        {
            this.login = login;
            this.password = password;
            this.adminFlag = adminFlag;
        }
        internal override void Execute()
        {
            _executorCommands.Login(login,password,adminFlag);
        }
    }
}
using System;
using ExchangeOffice;
using Ninject;
using Presentation.WindowInterfaces;

namespace Presentation
{
    public class LoginWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ILoginWindow _window;
        private readonly ExecutorCommands _executorCommands;
        private readonly Account _account;
        public LoginWindowPresenter(IKernel kernel, ILoginWindow loginWindow,ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = loginWindow;
            _executorCommands = executorCommands;
            _account = new UnauthenticatedUser();
            _window.TryLogin += () => TryLogin(_window.Login, _window.Password, _window.AdminFlag);
        }

        private void TryLogin(string login, string password, bool adminFlag)
        {
            _executorCommands.LoginEvent = LoginEventHandler;

            if (_account.SendCommand(new LoginCommand(_executorCommands, login, password,adminFlag))) return;
            _window.ShowError("Invalid command");
        }

        private void LoginEventHandler(object sender, IServiceEventArgs e)
        {
            var operation = (LoginServiceEventArgs) e;
            if (e.Status)
            {
                if (_window.AdminFlag)
                {
                    var newWindow =_kernel.Get<AdminWindowPresenter>();
                    newWindow.Run();
                }
                else
                {
                    var newWindow =_kernel.Get<CashierWindowPresenter>();
                    newWindow.SetCashierName(operation.Account.Login);
                    newWindow.Run();
                }
                _window.Close();
            }
            else
            {
                _window.ShowError(e.Message);
            }
        }


        public void Run()
        {
            
            _window.Show();
        }
    }
}
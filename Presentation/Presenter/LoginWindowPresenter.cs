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
            if (_executorCommands is IEventsCommands)
            {
                ((IEventsCommands)_executorCommands).LoginEvent += LoginEventHandler;
            }

            if (_account.SendCommand(new LoginCommand(_executorCommands, login, password,adminFlag))) return;
            _window.ShowError("Invalid command");
        }

        private void LoginEventHandler(object sender, ServiceEventArgs e)
        {
            if (e.Status)
            {
                if (_window.AdminFlag)
                {
                    _kernel.Get<AdminWindowPresenter>().Run();
                }
                else
                {
                    _kernel.Get<CashierWindowPresenter>().Run();
                }
                _window.Close();
            }
            else
            {
                _window.ShowError(e.Message[0]);
            }
        }


        public void Run()
        {
            
            _window.Show();
        }
    }
}
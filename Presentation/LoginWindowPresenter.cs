using System;
using ExchangeOffice;
using Ninject;

namespace GraphicalUserInterface
{
    public class LoginWindowPresenter
    {
        private readonly IKernel _kernel;
        private readonly ILoginWindow _window;
        private readonly ExecutorCommands _executorCommands;
        

        public LoginWindowPresenter(IKernel kernel, ILoginWindow loginWindow,ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = loginWindow;
            _executorCommands = executorCommands;

            _window.TryLogin += () => TryLogin(_window.Login, _window.Password);
        }

        private void TryLogin(string login, string password)
        {
            if (_executorCommands is IEventsCommands)
            {
                ((IEventsCommands)_executorCommands).LoginEvent += LoginEventHandler;
            }
            if(!Account.Instance.SendCommand(new LoginCommand(_executorCommands,login,password)))
            {
                _window.ShowError("Invalid command");
                return;
            }   
        }

        private void LoginEventHandler(object sender, ServiceEventArgs e)
        {
            if (e.Status)
            {
                _window.Close();
                if (_window.AdminFlag)
                {
                    _kernel.Get<AdminWindowPresenter>().Run();
                }
                else
                {
                    _kernel.Get<CashierWindowPresenter>().Run();
                }
            }
        }
            

    }
}
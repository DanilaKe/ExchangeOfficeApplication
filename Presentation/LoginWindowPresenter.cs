using System;
using ExchangeOffice;
using Ninject;

namespace GraphicalUserInterface
{
    public class LoginWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ILoginWindow _window;
        private readonly ExecutorCommands _executorCommands;
        public LoginWindowPresenter(IKernel kernel, ILoginWindow loginWindow,ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = loginWindow;
            _executorCommands = executorCommands;

            _window.TryLogin += () => TryLogin(_window.Login, _window.Password, _window.AdminFlag);
        }

        private void TryLogin(string login, string password, bool adminFlag)
        {
            if (_executorCommands is IEventsCommands)
            {
                ((IEventsCommands)_executorCommands).LoginEvent += LoginEventHandler;
            }

            if (Account.Instance.SendCommand(new LoginCommand(_executorCommands, login, password,adminFlag))) return;
            _window.ShowError("Invalid command");
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
using System;
using ExchangeOffice;
using Gtk;

namespace GraphicalUserInterface
{
    public class App
    {
        private AdminWindow _adminWindow;
        private CashierWindow _cashierWindow;
        private DialogWindow _dialogWindow;
        private LoginWindow _loginWindow;
        private AboutWindow _aboutWindow;
        private IAccount _account;
        private ExecutorCommands _executorCommands;
        
        private static App instance;
        public static App getInstance()
        {
            if (instance == null)
            {
                instance = new App();
            }

            return instance;
        }
        private App()
        {
            _account = new UnauthenticatedUser();
            _adminWindow = new AdminWindow();
            _cashierWindow = new CashierWindow();
            _dialogWindow = new DialogWindow();
            _loginWindow = new LoginWindow();
            _aboutWindow = new AboutWindow();
        }

        public void SetExecutorCommands(ExecutorCommands executorCommands)
        {
            if (_executorCommands == null && executorCommands != null)
            {
                _executorCommands = executorCommands;
                if (_executorCommands is IEventsCommands)
                {
                    
                }
            }
            else
            {
                Console.WriteLine("Useless command");
            }
            
        }

        public void Run()
        {
            _loginWindow.OpenWindow();
                
            Application.Run();
        }

        internal void OpenCashierWindow()
        {
            _loginWindow.HideWindow();
            _cashierWindow.OpenWindow();
        }
        
        internal void OpenAboutWindow()
        {
            _aboutWindow.OpenWindow();
        }
        
        internal void OpenAdminWindow()
        {
            _loginWindow.HideWindow();
            _adminWindow.OpenWindow();
        }
        
        internal void TryCashierLogin(string login, string password)
        {
            _account.SendCommand(new LoginCommand(_executorCommands,login,password));
        }
    }
}
using ExchangeOffice;
using ExchangeOfficeCommands;
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
        private Account _account;
        private IExecutorCommands _executorCommands;
        
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
            // TODO _executorCommands = new ExecutorCommands();
            
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
    }
}
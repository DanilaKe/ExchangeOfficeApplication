﻿using ExchangeOfficeApplication.GUI;
using Executor_Commands;
using Gtk;

namespace ExchangeOfficeApplication
{
    public class App
    {
        private AdminWindow _adminWindow;
        private CashierWindow _cashierWindow;
        private DialogWindow _dialogWindow;
        private LoginWindow _loginWindow;
        private Account _account;
        private IExecutorCommands _executorCommands;

        public App()
        {
            _account = new UnauthenticatedUser();
            _adminWindow = new AdminWindow();
            _cashierWindow = new CashierWindow();
            _dialogWindow = new DialogWindow();
            _loginWindow = new LoginWindow();
            _executorCommands = new ExecutorCommands();
            
        }

        public void Run()
        {
            _loginWindow.OpenWindow();
                
            Application.Run();
        }
    }
}
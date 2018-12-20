using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DataSourceAccess;
using ExchangeOffice;
using Ninject;
using Presentation.WindowInterfaces;
using Account = ExchangeOffice.Account;

namespace Presentation
{
    public class CashierWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ICashierWindow _window;
        private readonly ExecutorCommands _executorCommands;

        public CashierWindowPresenter(IKernel kernel, ICashierWindow cashierWindow, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = cashierWindow;
            _executorCommands = executorCommands;

            _window.Exchange += () => Exchange(_window.Name, _window.ContributedCurrency,
                _window.TargetCurrency, _window.ContributedAmount);
            _window.RefreshExchangeRate += RefreshTodayRate;
            _executorCommands.ExchangeEvent = ExchangeEventHandler;
            _executorCommands.CurrencyRateEvent = ViewingTodayExchangeRateHandler;
        }

        private void Exchange(string name, Currency ContributedCurrency, Currency TargetCurrency, decimal amount)
        {   
            if (Account.Instance.SendCommand(new ExchangeCommand(_executorCommands, name,ContributedCurrency,TargetCurrency,amount))) return;
            _window.ShowError("Invalid command");
        }
        
        private void ExchangeEventHandler(object sender, IServiceEventArgs e)
        {
            var operation = (ExchangeServiceEventArgs) e;
            if (e.Status)
            {
                _window.ExchangeResult = operation.Exchange.GetReportOnOperation();
            }
            else
            {
                _window.ShowError(e.Message);
            }
        }

        public void SetCashierName(string name)
        {
            _window.CashierName = name;
        }

        private void ViewingTodayExchangeRateHandler(object sender, IServiceEventArgs e)
        {
            var operation = (ViewExchangeRateServiceEventArgs) e;
            if (operation.Status)
            {
                _window.TodayCourse = operation.CurrencyExchanges.GetTodayRate();
            }
            else
            {
                _window.ShowError(e.Message);
            }
        }

        public void RefreshTodayRate()
        {
            Account.Instance.SendCommand(new ViewingTodayRateCommand(_executorCommands));
        }
        
        public void Run()
        {
            RefreshTodayRate();
            _window.Show();
        }
    }
}
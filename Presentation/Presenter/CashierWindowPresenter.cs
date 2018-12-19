using System;
using System.Collections.Generic;
using System.Globalization;
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
        }

        private void Exchange(string name, Currency ContributedCurrency, Currency TargetCurrency, decimal amount)
        {
            _executorCommands.ExchangeEvent = ExchangeEventHandler;
            
            if (Account.Instance.SendCommand(new ExchangeCommand(_executorCommands, name,ContributedCurrency,TargetCurrency,amount))) return;
            _window.ShowError("Invalid command");
        }
        
        private void ExchangeEventHandler(object sender, IServiceEventArgs e)
        {
            var operation = (ExchangeServiceEventArgs) e;
            if (e.Status)
            {
                _window.ExchangeResult.Replace("%Date%",DateTime.Now.ToString(CultureInfo.InvariantCulture));
                _window.ExchangeResult.Replace("%Name%", operation.Exchange.Customer.Name);
                _window.ExchangeResult.Replace("%AccountNumber%", operation.Exchange.Customer.CustomerId.ToString());
              /*  _window.ExchangeResult.Replace("%ContributedCurrency%",
                    Enum.GetName(typeof(Currency),operation.Exchange.CurrencyExchange.ContributedCurrency));
                _window.ExchangeResult.Replace("%TargetCurrency%",
                    Enum.GetName(typeof(Currency),operation.Exchange.CurrencyExchange.TargetCurrency));*/
                _window.ExchangeResult.Replace("%ExchangeRates%",
                    operation.Exchange.CurrencyExchange.Rate.ToString(CultureInfo.InvariantCulture));
                _window.ExchangeResult.Replace("%ContributedAmount%",
                    operation.Exchange.ContributedAmount.ToString(CultureInfo.InvariantCulture));
                _window.ExchangeResult.Replace("%IssuedAmount%",
                    operation.Exchange.IssuedAmount.ToString(CultureInfo.InvariantCulture));
                _window.ExchangeResult.Replace("%TodayLimit%",
                    operation.Exchange.Customer.DailyLimit.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                _window.ShowError(e.Message);
            }
        }

        public void InitCurrencies()
        {
            
        }

        public void SetCashierName(string name)
        {
            _window.CashierName = name;
        }
        
        public void Run()
        {
            _window.Show();
        }
    }
}
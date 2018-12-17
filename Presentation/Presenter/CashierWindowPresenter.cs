using System;
using DataSourceAccess;
using ExchangeOffice;
using Ninject;
using Account = ExchangeOffice.Account;

namespace GraphicalUserInterface
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
            if (_executorCommands is IEventsCommands)
            {
                ((IEventsCommands)_executorCommands).ExchangeEvent += ExchangeEventHandler;
            }
            
            if (Account.Instance.SendCommand(new ExchangeCommand(_executorCommands, name,ContributedCurrency,TargetCurrency,amount))) return;
            _window.ShowError("Invalid command");
        }
        
        private void ExchangeEventHandler(object sender, ServiceEventArgs e)
        {
            if (e.Status)
            {
                var splitArgs = e.Message.Split('/');
                var result = $"Дата : {splitArgs[0]}\n" +
                             $"Счет : {splitArgs[1]}\n\n" +
                             $"Имя : {splitArgs[2]}\n\n" +
                             $"Валюта операции : {splitArgs[3]}\n" +
                             $"Целевая валюта : {splitArgs[4]}\n" +
                             $"Курс : {splitArgs[5]}\n" +
                             $"Внесенная сумма : {splitArgs[6]}\n" +
                             $"Полученная сумма : {splitArgs[7]}\n\n" +
                             $"Сегодняшний лимит : {splitArgs[8]}";
                _window.ShowExchangeResult(result);
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
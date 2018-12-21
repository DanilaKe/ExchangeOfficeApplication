using System.Drawing;
using DataSourceAccess;
using ExchangeOffice;
using Ninject;
using Presentation.WindowInterfaces;
using Account = ExchangeOffice.Account;
using System.Drawing.Printing;
using System.IO;
using System.Security;

namespace Presentation
{
    public class CashierWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ICashierWindow _window;
        private readonly ExecutorCommands _executorCommands;
        private string Bill;

        public CashierWindowPresenter(IKernel kernel, ICashierWindow cashierWindow, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = cashierWindow;
            _executorCommands = executorCommands;

            _window.Exchange += () => Exchange(_window.Name, _window.ContributedCurrency,
                _window.TargetCurrency, _window.ContributedAmount);
            _window.CallAboutWindow += CallingAboutWindow;
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
                 Bill = operation.Exchange.GetReportOnOperation();
                _window.ExchangeResult = Bill;
                if (_window.PrintFlag)
                {
                    _kernel.Get<Printer>().Print(Bill);
                }
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

        private void CallingAboutWindow()
        {
            _kernel.Get<AboutWindowPresenter>().Run();
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
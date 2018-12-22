using System.Drawing;
using DataSourceAccess;
using ExchangeOffice;
using Ninject;
using Presentation.WindowInterfaces;
using Account = ExchangeOffice.Account;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security;

namespace Presentation
{
    public class CashierWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ICashierWindow _window;
        private readonly ExecutorCommands _executorCommands;
        private bool InvalidDataFlag;
        private string Bill;

        public CashierWindowPresenter(IKernel kernel, ICashierWindow cashierWindow, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = cashierWindow;
            _executorCommands = executorCommands;

            _window.Exchange += () => Exchange(_window.Name, _window.ContributedCurrency,
                _window.TargetCurrency, _window.ContributedAmount);
            _window.CallAboutWindow += CallingAboutWindow;
            _window.Quit += QuitHandler;
            _window.InvalidData += InvalidData;
            _window.RefreshExchangeRate += RefreshTodayRate;
            _window.CallHistoryWindow += CallingHistoryWindow;
            _executorCommands.ExchangeEvent = ExchangeEventHandler;
            _executorCommands.CurrencyRateEvent = ViewingTodayExchangeRateHandler;
        }

        private void Exchange(string name, Currency ContributedCurrency, Currency TargetCurrency, decimal amount)
        {   
            var exchangeCommand = new ExchangeCommand(_executorCommands, name,ContributedCurrency,TargetCurrency,amount);
            if (!InvalidDataFlag)
            {
                if (Account.Instance.SendCommand(exchangeCommand)) return;
                _kernel.Get<DialogWindowPresenter>().SendMessage("Invalid command.");
            }
            InvalidDataFlag = false;
        }
        
        private void ExchangeEventHandler(object sender, ServiceEventArgs<Exchange> e)
        {
            if (e.Status)
            {
                 Bill = e.Result.Last().GetReportOnOperation();
                _window.ExchangeResult = Bill;
                if (_window.PrintFlag)
                {
                    _kernel.Get<Printer>().Print(Bill);
                }
            }
            else
            {
                _kernel.Get<DialogWindowPresenter>().SendMessage(e.Message);
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
        
        private void CallingHistoryWindow()
        {
            _kernel.Get<HistoryWindowPresenter>().Run();
        }

        private void QuitHandler()
        {
            _window.Close();
            _kernel.Get<LoginWindowPresenter>().Run();
        }

        private void ViewingTodayExchangeRateHandler(object sender, ServiceEventArgs<CurrencyExchange> e)
        {
            if (e.Status)
            {
                _window.TodayCourse = e.Result.GetTodayRate();
            }
            else
            {
                _kernel.Get<DialogWindowPresenter>().SendMessage(e.Message);
            }
        }

        private void InvalidData()
        {
            InvalidDataFlag = true;
            _kernel.Get<DialogWindowPresenter>().SendMessage("Invalid data.");
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
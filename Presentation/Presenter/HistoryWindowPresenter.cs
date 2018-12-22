using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using DataSourceAccess;
using ExchangeOffice;
using ExchangeOffice.Service;
using Ninject;
using Presentation.WindowInterfaces;
using Account = ExchangeOffice.Account;

namespace Presentation
{
    public class HistoryWindowPresenter : IPresenter
    {
        private IKernel _kernel;
        private IHistoryWindow _window;
        private ExecutorCommands _executorCommands;

        public HistoryWindowPresenter(IKernel kernel, IHistoryWindow window, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = window;
            _executorCommands = executorCommands;

            _executorCommands.HistoryEvent += GetedHistoryHandler;
            InitHistory();
        }

        private void InitHistory()
        {
            Account.Instance.SendCommand(new ViewingHistoryCommand(_executorCommands));
        }

        private void GetedHistoryHandler(object sender, ServiceEventArgs<Exchange> e)
        {
            foreach (var i in e.Result)
            {
                _window.Rate = $"{i.CurrencyExchange.ContributedCurrency}-{i.CurrencyExchange.TargetCurrency}";
            }

            foreach (var i in e.Result.Select(x => x.Customer ).Distinct())
            {
                _window.Customer = i.Name;
            }

            foreach (var i in e.Result.Select(x => x.Date).Distinct())
            {
                _window.Date = i.DateTime.ToString(CultureInfo.InvariantCulture);
            }
            
        }

        public void Run()
        {
            _window.Show();
        }
    }
}
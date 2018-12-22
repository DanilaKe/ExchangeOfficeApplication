using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
        private List<Exchange> history;

        public HistoryWindowPresenter(IKernel kernel, IHistoryWindow window, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = window;
            _executorCommands = executorCommands;
            _window.RefreshEvent += Refresh;
            _executorCommands.HistoryEvent += GetedHistoryHandler;
            InitHistory();
        }

        private void Refresh()
        {
            var text = new StringBuilder();
            foreach (var i in history.Select(x=>x).Where(x => x.Date?.DateTime.ToString(CultureInfo.InvariantCulture) ==_window.Date &&
                                                          x.Customer?.Name == _window.Customer &&
                                                          $"{x.CurrencyExchange?.ContributedCurrency}-{x.CurrencyExchange?.TargetCurrency}" == _window.Rate))
            {
                text.Append("\n------------------------------------------\n");
                text.Append(i.GetReportOnOperation());  
                text.Append("\n------------------------------------------\n");
            }

            _window.History = text.ToString();
        }

        private void InitHistory()
        {
            Account.Instance.SendCommand(new ViewingHistoryCommand(_executorCommands));
        }

        private void GetedHistoryHandler(object sender, ServiceEventArgs<Exchange> e)
        {
            history = e.Result;
            foreach (var i in e.Result)
            {
                _window.Rate = $"{i.CurrencyExchange.ContributedCurrency}-{i.CurrencyExchange.TargetCurrency}";
            }

            foreach (var i in e.Result.Select(x => x.Customer ).Distinct())
            {
                _window.Customer = i?.Name;
            }

            foreach (var i in e.Result.Select(x => x.Date).Distinct())
            {
                _window.Date = i?.DateTime.ToString(CultureInfo.InvariantCulture);
            }
            
        }

        public void Run()
        {
            _window.Show();
        }
    }
}
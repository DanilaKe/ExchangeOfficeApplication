using System;
using System.Collections.Generic;
using DataSourceAccess;

namespace Presentation.WindowInterfaces
{
    public interface ICashierWindow : IView
    {
        bool PrintFlag { get; }
        string Name { get;}
        Currency ContributedCurrency { get; }
        Currency TargetCurrency { get; }
        decimal ContributedAmount { get;  }
        void ShowError(string message);
        string ExchangeResult { get; set; }
        string CashierName { get; set; }
        string TodayCourse { get; set; }

        event Action Exchange;
        event Action InvalidData;
        event Action CallAboutWindow;
        event Action RefreshExchangeRate;
        event Action Quit;
    }
}
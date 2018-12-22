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
        decimal ContributedAmount { get; }
        string ExchangeResult { set; }
        string CashierName { set; }
        string TodayCourse { set; }

        event Action Exchange;
        event Action InvalidData;
        event Action CallAboutWindow;
        event Action RefreshExchangeRate;
        event Action Quit;
        event Action CallHistoryWindow;
    }
}
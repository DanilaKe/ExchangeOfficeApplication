using System;
using DataSourceAccess;

namespace GraphicalUserInterface
{
    public interface ICashierWindow : IView
    {
        string Name { get;}
        Currency ContributedCurrency { get; }
        Currency TargetCurrency { get; }
        decimal ContributedAmount { get;  }
        void ShowError(string message);

        event Action Exchange;
    }
}
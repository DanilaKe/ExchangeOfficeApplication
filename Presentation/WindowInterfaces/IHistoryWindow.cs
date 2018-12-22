using System;
using System.Collections.Generic;
using DataSourceAccess;

namespace Presentation.WindowInterfaces
{
    public interface IHistoryWindow : IView
    {
        string Date { get; set; }
        string Rate { get; set; }
        string Customer { get; set; }
        event Action RefreshEvent;
    }
}
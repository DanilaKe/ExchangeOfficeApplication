using System;
using DataSourceAccess;

namespace Presentation.WindowInterfaces
{
    public interface IAdminWindow : IView
    {
        Currency ContributedCurrency { get; }
        Currency TargetCurrency { get; }
        
        decimal Rate { get; }
        
        event Action CallAboutWindow;
        event Action UpdateRate;
        event Action Quit;
        event Action InvalidData;
    }
}
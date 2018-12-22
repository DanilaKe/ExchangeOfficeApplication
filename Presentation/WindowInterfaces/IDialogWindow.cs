using System;

namespace Presentation.WindowInterfaces
{
    public interface IDialogWindow : IView
    {
        string Message { get; set; }
        event Action OKButtonClick;

    }
}
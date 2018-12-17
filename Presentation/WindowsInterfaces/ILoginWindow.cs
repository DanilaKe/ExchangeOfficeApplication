using System;

namespace GraphicalUserInterface
{
    public interface ILoginWindow : IView
    {
        string Login { get; }
        string Password { get;  }
        void ShowError(string message);
        event Action TryLogin;
        
        bool AdminFlag { get; set; }

    }
}
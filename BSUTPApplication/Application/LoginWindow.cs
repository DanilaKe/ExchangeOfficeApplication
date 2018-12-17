using Gtk;
using System;
using Action = System.Action;

namespace GraphicalUserInterface
{
    public class LoginWindow : ILoginWindow, IDisposable
    {
        private bool disposed = false;
        [Builder.Object] private Entry LoginEntry;
        [Builder.Object] private Entry PasswordEntry;
        [Builder.Object] private Label ErrorMessage;
        [Builder.Object] private Window _window;
        public event Action TryLogin;
        public bool AdminFlag { get; set; }
        public string Login => LoginEntry.Text;
        public string Password => PasswordEntry.Text;
        public void Show() =>  _window.Visible = true;
        public void Close() => Dispose();
        public void ShowError(string message) => ErrorMessage.Text = message;

        private Builder GuiBuilder;
        
        public LoginWindow() 
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/LoginWindow.glade");
                GuiBuilder.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected void OkButtonClicked(object sender, EventArgs a)
        {
            ErrorMessage.Text = string.Empty;
            TryLogin?.Invoke();
        }
        
        protected void ExitButtonClicked(object sender, EventArgs a)
        {
            Application.Quit();
        }
        
        protected void  AdministratorSwitchActivate(object sender, ButtonReleaseEventArgs a)
        {
            AdminFlag = !AdminFlag;
        }
        
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _window.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            _window.Close();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
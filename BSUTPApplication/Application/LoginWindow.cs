using Gtk;
using System;

namespace GraphicalUserInterface
{
    public class LoginWindow
    {
        [Builder.Object] private Entry LoginEntry;
        [Builder.Object] private Entry PasswordEntry;
        [Builder.Object] private Window _window;

        private bool adminFlag;
        
        private Builder GuiBuilder;
        
        public LoginWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile("./Presentation/GuiGlade/LoginWindow.glade");
                GuiBuilder.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void OpenWindow()
        {
            _window.Visible = true;
        }
        
        internal void HideWindow()
        {
            _window.Visible = false;
        }
        
        protected void OkButtonClicked(object sender, EventArgs a)
        {
            if (adminFlag)
            {
                App.getInstance().OpenAdminWindow();
            }
            else
            {
                App.getInstance().TryCashierLogin("a","a");
            }
        }
        
        protected void ExitButtonClicked(object sender, EventArgs a)
        {
            Console.WriteLine("Exit");
            Application.Quit();
        }
        
        protected void  AdministratorSwitchActivate(object sender, ButtonReleaseEventArgs a)
        {
            adminFlag = !adminFlag;
        }
        
        protected void ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
    }
}
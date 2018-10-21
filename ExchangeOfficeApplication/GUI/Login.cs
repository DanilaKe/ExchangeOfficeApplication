using Gtk;
using System;

namespace ExchangeOfficeApplication.GUI
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class Login
    {
        [Builder.Object] private Label LoginLable;
        [Builder.Object] private Label PasswordLable;
        [Builder.Object] private Entry LoginEntry;
        [Builder.Object] private Entry PasswordEntry;
        [Builder.Object] private Window LoginWindow;
        
        private Builder GuiBuilder;
        
        public Login()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile(
                    "./GUI/LoginWindow.glade");
                GuiBuilder.Autoconnect(this);
                LoginWindow.Visible = true;
                Application.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        protected void  OkButtonClicked(object sender, EventArgs a)
        {
            Console.WriteLine("OK");
            // TODO
        }
        
        protected void  ExitButtonClicked(object sender, EventArgs a)
        {
            Console.WriteLine("Exit");
            // TODO
        }
        
        protected void  AdministratorSwitchActivate(object sender, ButtonReleaseEventArgs a)
        {
            Console.WriteLine("Admin");
            // TODO
        }
        
        protected void  ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
    }
}
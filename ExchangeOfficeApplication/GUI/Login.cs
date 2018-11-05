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
        [Builder.Object] private Entry LoginEntry;
        [Builder.Object] private Entry PasswordEntry;
        [Builder.Object] private Window LoginWindow;

        private bool adminFlag;
        
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
            LoginWindow.Visible = false;
            new CashierWindow();
            Console.WriteLine("OK");
            // TODO
        }
        
        protected void  ExitButtonClicked(object sender, EventArgs a)
        {
            Console.WriteLine("Exit");
            Application.Quit();
            // TODO
        }
        
        protected void  AdministratorSwitchActivate(object sender, ButtonReleaseEventArgs a)
        {
            adminFlag = !adminFlag;
            Console.WriteLine($"Admin : {adminFlag}");
        }
        
        protected void  ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
    }
}
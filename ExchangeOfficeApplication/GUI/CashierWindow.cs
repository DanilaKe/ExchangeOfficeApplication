using Gtk;
using System;

namespace ExchangeOfficeApplication.GUI
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class CashierWindow
    {
        [Builder.Object] private Label LoginLable;
        [Builder.Object] private Label PasswordLable;
        [Builder.Object] private Entry LoginEntry;
        [Builder.Object] private Entry PasswordEntry;
        [Builder.Object] private Window Cashier;
        
        private Builder GuiBuilder;
        
        public CashierWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile(
                    "./GUI/CashierWindow.glade");
                GuiBuilder.Autoconnect(this);
                Cashier.Visible = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        protected void  ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
    }
}
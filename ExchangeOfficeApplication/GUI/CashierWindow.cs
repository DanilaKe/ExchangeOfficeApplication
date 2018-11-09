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
        [Builder.Object] private TextBuffer TodayCourse;
        [Builder.Object] private TextBuffer ExchangeResult;
        [Builder.Object] private Entry FirstName;
        [Builder.Object] private ComboBoxText ContributedСurrency;
        [Builder.Object] private ComboBoxText TargetCurrency;
        [Builder.Object] private Entry ContributedAmount;
        [Builder.Object] private Window Cashier;
        [Builder.Object] private AboutDialog AboutDialog;
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

        protected void ClickedApplyButton(object sender, EventArgs a)
        {
            //TODO    
        }
        
        protected void ClickedClearButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ClickedRefreshButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ClickedCloseButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
        
        protected void ClickedAboutButton(object sender, EventArgs a)
        {
            AboutDialog.Visible = true;
        }
        
        protected void ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
        
        protected void ClickedQuitButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ActivatePurchaseButton(object sender, EventArgs a)
        {
            //TODO
        }

        protected void CloseAboutWindow(object sender, EventArgs a)
        {
            GuiBuilder.AddFromFile(
                "./GUI/CashierWindow.glade");
            GuiBuilder.Autoconnect(this);
        }
        
        protected void CloseAboutWindow(object sender, ResponseArgs a)
        {
            AboutDialog.Visible = false;
        }
    }
}
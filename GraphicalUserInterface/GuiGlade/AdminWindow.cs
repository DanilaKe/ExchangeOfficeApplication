using Gtk;
using System;

namespace ExchangeOfficeApplication.GUI
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class AdminWindow
    {
        [Builder.Object] private TextBuffer Log;
        [Builder.Object] private ComboBoxText ContributedСurrency;
        [Builder.Object] private ComboBoxText TargetCurrency;
        [Builder.Object] private Entry PurchaseRate;
        [Builder.Object] private Entry SellingRate;
        [Builder.Object] private Window Admin;
        [Builder.Object] private AboutDialog AboutDialog;
        
        private Builder GuiBuilder;
        
        public AdminWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile(
                    "./GUI/AdminWindow.glade");
                GuiBuilder.Autoconnect(this);
                Admin.Visible = true;
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
                "./GUI/AdminWindow.glade");
            GuiBuilder.Autoconnect(this);
        }
        
        protected void CloseAboutWindow(object sender, ResponseArgs a)
        {
            AboutDialog.Visible = false;
        }
    }
}
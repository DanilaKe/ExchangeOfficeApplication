using Gtk;
using System;

namespace GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class CashierWindow : ICashierWindow
    {
        [Builder.Object] private TextBuffer TodayCourse;
        [Builder.Object] private TextBuffer ExchangeResult;
        [Builder.Object] private Entry FirstName;
        [Builder.Object] private ComboBoxText ContributedСurrency;
        [Builder.Object] private ComboBoxText TargetCurrency;
        [Builder.Object] private Entry ContributedAmount;
        [Builder.Object] private Window _window;
        [Builder.Object] private Dialog HistoryDialog;
        [Builder.Object] private Entry Client;
        [Builder.Object] private Window CustumerHistory;
        [Builder.Object] private TextBuffer History;
        private Builder GuiBuilder;
        
        public CashierWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile("./Presentation/GuiGlade/CashierWindow.glade");
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

        protected void ClickedApplyButton(object sender, EventArgs a)
        {
            new DialogWindow();    
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
            App.getInstance().OpenAboutWindow();
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
        
        protected void ClickedCloseHistoryButton(object sender, EventArgs a)
        {
            HistoryDialog.Visible = false;
        }
        
        protected void ClickedHistoryButton(object sender, EventArgs a)
        {
            HistoryDialog.Visible = true;
        }
        
        protected void ClickedSearchButton(object sender, EventArgs a)
        {
            CustumerHistory.Visible = true;
            HistoryDialog.Visible = false;
        }
        
        protected void CloseHistoryButton(object sender, EventArgs a)
        {
            GuiBuilder.AddFromFile(
                "./GUI/CashierWindow.glade");
            GuiBuilder.Autoconnect(this);
        }
        
        protected void CloseHistory(object sender, EventArgs a)
        {
            CustumerHistory.Visible = false;
            GuiBuilder.AddFromFile(
                "./GUI/CashierWindow.glade");
            GuiBuilder.Autoconnect(this);
        }
    }
}
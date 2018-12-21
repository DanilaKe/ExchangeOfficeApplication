using Gtk;
using System;
using Presentation.WindowInterfaces;

namespace BSUTPApplication.GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class AdminWindow : IAdminWindow
    {
        [Builder.Object] private TextBuffer Log;
        [Builder.Object] private ComboBoxText ContributedСurrency;
        [Builder.Object] private ComboBoxText TargetCurrency;
        [Builder.Object] private Entry PurchaseRate;
        [Builder.Object] private Entry SellingRate;
        [Builder.Object] private Window _window;
        
        private Builder GuiBuilder;
        
        public AdminWindow()
        {
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/AboutWindow.glade");
                GuiBuilder.Autoconnect(this);   
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
            //TODO
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

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
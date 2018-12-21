using Gtk;
using System;
using Presentation.WindowInterfaces;

namespace BSUTPApplication.GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class AdminWindow : IAdminWindow,IDisposable
    {
        private bool disposed = false;
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
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/AdminWindow.glade");
                GuiBuilder.Autoconnect(this);   
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

        public void Dispose(bool disposing)
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
        
        public void Show() => _window.Visible = true;
        public void Close() => Dispose();
        
    }
}
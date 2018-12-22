using Gtk;
using System;
using DataSourceAccess;
using Presentation.WindowInterfaces;
using Action = System.Action;

namespace BSUTPApplication.GraphicalUserInterface
{
    public class AdminWindow : IAdminWindow,IDisposable
    {
        private bool disposed = false;
        [Builder.Object] private ComboBoxText ContributedCurrencyComboBoxText;
        [Builder.Object] private ComboBoxText TargetCurrencyComboBoxText;
        [Builder.Object] private Entry RateEntry;
        [Builder.Object] private Window _window;
        
        private Builder GuiBuilder;
        
        public Currency ContributedCurrency
        {
            get
            {
                if (Enum.TryParse<Currency>(ContributedCurrencyComboBoxText.ActiveText,out var value))
                {
                    return value;
                }
                InvalidData?.Invoke();
                return 0;
            }
        }

        public Currency TargetCurrency
        {
            get
            {
                if (TargetCurrencyComboBoxText.ActiveText == ContributedCurrencyComboBoxText.ActiveText)
                {
                    InvalidData?.Invoke();
                    return 0;
                }
                if (Enum.TryParse<Currency>(TargetCurrencyComboBoxText.ActiveText,out var value))
                {
                    return value;
                }
                InvalidData?.Invoke();
                return 0;
            }
        }

        public decimal Rate
        {
            get
            {
                if (decimal.TryParse(RateEntry.Text.Replace(".",","),out var value))
                {
                    return value;
                }
                InvalidData?.Invoke();
                return 0;
            }
        }
        public event Action CallAboutWindow;
        public event Action UpdateRate;
        public event Action Quit;
        public event Action InvalidData;

        public AdminWindow()
        {
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/AdminWindow.glade");
                GuiBuilder.Autoconnect(this);   
            }
            
            InitCurrencies();
        }

        protected void ClickedApplyButton(object sender, EventArgs a)
        {
            UpdateRate?.Invoke();
        }

        protected void ClickedAboutButton(object sender, EventArgs a)
        {
            CallAboutWindow?.Invoke();
        }
        
        protected void ClickedQuitButton(object sender, EventArgs a)
        {
            Quit?.Invoke();
        }
        
        protected void ClickedCloseButton(object sender, EventArgs a)
        {
            Close();
            Application.Quit();
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
        
        private void InitCurrencies()
        {
            foreach (var i in Enum.GetNames(typeof(Currency)))
            {
                ContributedCurrencyComboBoxText.AppendText(i);
                TargetCurrencyComboBoxText.AppendText(i);
            }
                
        }
        
        public void Show() => _window.Visible = true;
        public void Close() => Dispose();
        
    }
}
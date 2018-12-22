using Gtk;
using System;
using System.Collections.Generic;
using DataSourceAccess;
using Ninject;
using Presentation;
using Presentation.WindowInterfaces;
using Action = System.Action;

namespace BSUTPApplication.GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public sealed class CashierWindow : ICashierWindow, IDisposable
    {
        private bool disposed;
        private readonly IKernel _kernel;
        private readonly Builder GuiBuilder;
        
        [Builder.Object] private TextBuffer TodayСourseTextBuffer;
        [Builder.Object] private TextBuffer ExchangeResultTextBuffer;
        [Builder.Object] private Entry NameEntry;
        [Builder.Object] private Label CashierNameLable;
        [Builder.Object] private ComboBoxText ContributedСurrencyComboBoxText;
        [Builder.Object] private ComboBoxText TargetCurrencyComboBoxText;
        [Builder.Object] private Entry ContributedAmountEntry;
        [Builder.Object] private Window Window;
        [Builder.Object] private CheckButton PrintFlagCheckButton;

        public string TodayCourse
        {
            get => TodayСourseTextBuffer.Text;
            set => TodayСourseTextBuffer.Text = value;
        }
        public string ExchangeResult
        {
            get => ExchangeResultTextBuffer.Text;
            set => ExchangeResultTextBuffer.Text = value;
        }

        public string CashierName
        {
            get => CashierNameLable.Text;
            set => CashierNameLable.Text = value;
        }

        public bool PrintFlag => PrintFlagCheckButton.Active;
        public string Name => NameEntry.Text;

        public Currency ContributedCurrency
        {
            get
            {
                if (Enum.TryParse<Currency>(ContributedСurrencyComboBoxText.ActiveText,out var value))
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
                if (TargetCurrencyComboBoxText.ActiveText == ContributedСurrencyComboBoxText.ActiveText)
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

        public decimal ContributedAmount
        {
            get
            {
                if (decimal.TryParse(ContributedAmountEntry.Text,out var value))
                {
                    return value;
                }
                InvalidData?.Invoke();
                return 0;
            }
        }
            
        public void ShowError(string message)
        {
            Console.WriteLine("111");
        }

        public event Action Exchange;
        public event Action CallAboutWindow;
        public event Action RefreshExchangeRate;
        public event Action Quit;

        public event Action InvalidData;

        public CashierWindow(IKernel kernel)
        {
            _kernel = kernel;
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/CashierWindow.glade");
                GuiBuilder.Autoconnect(this);
            }
            
            InitCurrencies();
        }

        private void ClickedApplyButton(object sender, EventArgs a)
        {
            Exchange?.Invoke();   
        }

        private void ClickedClearButton(object sender, EventArgs a)
        {
            NameEntry.Text = string.Empty;
            ContributedAmountEntry.Text = string.Empty;
        }

        private void ClickedRefreshButton(object sender, EventArgs a)
        {
            RefreshExchangeRate?.Invoke();
        }

        private void ClickedCloseButton(object sender, EventArgs a)
        {
            Close();
            Application.Quit();
        }

        private void ClickedAboutButton(object sender, EventArgs a)
        {
            CallAboutWindow?.Invoke();
        }

        private void ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }

        private void ClickedQuitButton(object sender, EventArgs a)
        {
            Quit?.Invoke();
        }

        private void ActivatePurchaseButton(object sender, EventArgs a)
        {
            //TODO
        }

        private void ClickedCloseHistoryButton(object sender, EventArgs a)
        {
            //TODO
        }

        private void ClickedHistoryButton(object sender, EventArgs a)
        {
            //TODO
        }

        private void ClickedSearchButton(object sender, EventArgs a)
        {
            //TODO
        }

        private void CloseHistoryButton(object sender, EventArgs a)
        {
        }

        private void CloseHistory(object sender, EventArgs a)
        {
        }

        private void InitCurrencies()
        {
            foreach (var i in Enum.GetNames(typeof(Currency)))
            {
                ContributedСurrencyComboBoxText.AppendText(i);
                TargetCurrencyComboBoxText.AppendText(i);
            }
                
        }
        
        public void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    Window.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Window.Close();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Show() =>  Window.Visible = true;
        public void Close() => Dispose();
    }
}
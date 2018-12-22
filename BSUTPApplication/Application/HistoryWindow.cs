using Gtk;
using System;
using Presentation.WindowInterfaces;
using Action = System.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Presentation.WindowInterfaces;

namespace BSUTPApplication.GraphicalUserInterface
{
    public class HistoryWindow : IHistoryWindow,IDisposable
    {
        private Builder GuiBuilder;
        [Builder.Object] private Window _window;
        [Builder.Object] private TextBuffer HistoryTextBuffer;
        [Builder.Object] private ComboBoxText DateComboBoxText;
        [Builder.Object] private ComboBoxText RateComboBoxText;
        [Builder.Object] private ComboBoxText CustomerComboBoxText;
        private List<string> RateList = new List<string>();
        public HistoryWindow()
        {
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/HistoryWindow.glade");
                GuiBuilder.Autoconnect(this);   
            }
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    _window.Visible = false;
                }
            }
            disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Show() =>  _window.Visible = true;
        public void Close() => Dispose();

        public string Date
        {
            get =>  DateComboBoxText.ActiveText;
            set => DateComboBoxText.AppendText(value);
        }
        public string Rate
        {
            get=> RateComboBoxText.ActiveText;
            set
            {
                if (RateList.All(x => x != value))
                {
                    RateList.Add(value);
                    RateComboBoxText.AppendText(value);
                }
            }
        }
        public string Customer
        {
            get=> CustomerComboBoxText.ActiveText;
            set => CustomerComboBoxText.AppendText(value);
            }
        private void UpdateButtonClicked(object sender, EventArgs a) => RefreshEvent?.Invoke();
        public event Action RefreshEvent;
    }
}
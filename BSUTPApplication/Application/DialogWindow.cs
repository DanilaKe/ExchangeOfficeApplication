using Gtk;
using System;
using Presentation.WindowInterfaces;
using Action = System.Action;

namespace BSUTPApplication.GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class DialogWindow : IDialogWindow
    {
        private bool disposed;
        [Builder.Object] private Dialog _window;
        [Builder.Object] private Label MessageLabel;
        private Builder GuiBuilder;
        
        public DialogWindow()
        {
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/DialogWindow.glade");
                GuiBuilder.Autoconnect(this);   
            }
        }
        
        public string Message
        {
            get => MessageLabel.Text;
            set => MessageLabel.Text = value;
            
        }
        protected void ClickedCloseButton(object sender, EventArgs a)
        {
            _window.Visible = false;
            Dispose();
        }

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
        public event Action OKButtonClick;
    }
}
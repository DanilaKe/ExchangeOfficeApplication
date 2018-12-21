using Gtk;
using System;
using Presentation.WindowInterfaces;

namespace BSUTPApplication.GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class AboutWindow : IAboutWindow, IDisposable
    {
        [Builder.Object] private AboutDialog _window;
        private bool disposed = false;
        
        private Builder GuiBuilder;
        
        public AboutWindow()
        {
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/AboutWindow.glade");
                GuiBuilder.Autoconnect(this);   
            }
        }

        protected void CloseAboutWindow(object sender, EventArgs a) => Close();
        protected void CloseAboutWindow(object sender, ResponseArgs a) => Close();

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
            _window.Visible = false;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Show() => _window.Visible = true;
        public void Close() => Dispose();
    }
}
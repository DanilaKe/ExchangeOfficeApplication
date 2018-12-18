using Gtk;
using System;
using Presentation.WindowInterfaces;

namespace BSUTPApplication.GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class DialogWindow : IDialogWindow
    {
        [Builder.Object] private Dialog dialogWindow;
        private Builder GuiBuilder;
        
        public DialogWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile("./Presentation/GuiGlade/DialogWindow.glade");
                GuiBuilder.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void OpenWindow()
        {
            dialogWindow.Visible = true;
        }
        
        protected void ClickedOkButton(object sender, EventArgs a)
        {
            dialogWindow.Visible = false;
        }
        
        protected void ExitButton(object sender, EventArgs a)
        {
            GuiBuilder.AddFromFile(
                "./GUI/DialogWindow.glade");
            GuiBuilder.Autoconnect(this);
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
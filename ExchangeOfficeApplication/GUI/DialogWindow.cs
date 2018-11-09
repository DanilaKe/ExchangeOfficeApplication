using Gtk;
using System;

namespace ExchangeOfficeApplication.GUI
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class DialogWindow
    {
        [Builder.Object] private Dialog dialogWindow;
        private Builder GuiBuilder;
        
        public DialogWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile(
                    "./GUI/DialogWindow.glade");
                GuiBuilder.Autoconnect(this);
                dialogWindow.Visible = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
    }
}
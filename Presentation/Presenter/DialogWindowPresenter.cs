using Ninject;
using Presentation.WindowInterfaces;

namespace Presentation
{
    public class DialogWindowPresenter : IPresenter
    {
        private IKernel _kernel;
        private IDialogWindow _window;
        public DialogWindowPresenter(IKernel kernel, IDialogWindow window)
        {
            _kernel = kernel;
            _window = window;
        }

        public void SendMessage(string message)
        {
            _window.Message = message;
            Run();
        }
        public void Run()
        {
            _window.Show();
        }
    }
}
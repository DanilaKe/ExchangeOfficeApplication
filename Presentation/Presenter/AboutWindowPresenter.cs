using Ninject;
using Presentation.WindowInterfaces;

namespace Presentation
{
    public class AboutWindowPresenter : IPresenter
    {
        private IKernel _kernel;
        private IAboutWindow _window;

        public AboutWindowPresenter(IKernel kernel, IAboutWindow window)
        {
            _kernel = kernel;
            _window = window;
        }
        public void Run()
        {
            _window.Show();
        }
    }
}
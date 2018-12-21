using Ninject;
using Presentation.WindowInterfaces;

namespace Presentation
{
    public class AdminWindowPresenter : IPresenter
    {
        private IKernel _kernel;
        private IAdminWindow _window;

        public AdminWindowPresenter(IKernel kernel, IAdminWindow window)
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
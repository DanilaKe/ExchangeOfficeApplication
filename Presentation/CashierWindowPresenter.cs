using ExchangeOffice;
using Ninject;

namespace GraphicalUserInterface
{
    public class CashierWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ICashierWindow _window;
        private readonly ExecutorCommands _executorCommands;
        public CashierWindowPresenter(IKernel kernel, ICashierWindow cashierWindow,ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = cashierWindow;
            _executorCommands = executorCommands;

            /*_window.TryLogin += () => TryLogin(_window.Login, _window.Password);*/
        }
        public void Run()
        {
            _window.Show();
        }
    }
}
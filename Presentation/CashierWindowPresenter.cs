using DataSourceAccess;
using ExchangeOffice;
using Ninject;
using Account = ExchangeOffice.Account;

namespace GraphicalUserInterface
{
    public class CashierWindowPresenter : IPresenter
    {
        private readonly IKernel _kernel;
        private readonly ICashierWindow _window;
        private readonly ExecutorCommands _executorCommands;

        public CashierWindowPresenter(IKernel kernel, ICashierWindow cashierWindow, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = cashierWindow;
            _executorCommands = executorCommands;

            _window.Exchange += () => Exchange(_window.Name, _window.ContributedCurrency,
                _window.TargetCurrency, _window.ContributedAmount);
        }

        private void Exchange(string name, Currency ContributedCurrency, Currency TargetCurrency, decimal amount)
        {
            if (_executorCommands is IEventsCommands)
            {
                ((IEventsCommands)_executorCommands).ExchangeEvent += ExchangeEventHandler;
            }
            
            if (Account.Instance.SendCommand(new ExchangeCommand(_executorCommands, name,ContributedCurrency,TargetCurrency,amount))) return;
            _window.ShowError("Invalid command");
        }
        
        private void ExchangeEventHandler(object sender, ServiceEventArgs e)
        {
            if (e.Status)
            {
                _kernel.Get<AdminWindowPresenter>().Run();
            }
            else
            {
                _window.ShowError(e.Message);
            }
        }
        
        public void Run()
        {
            _window.Show();
        }
    }
}
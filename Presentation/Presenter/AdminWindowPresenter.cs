using DataSourceAccess;
using ExchangeOffice;
using Ninject;
using Presentation.WindowInterfaces;
using Account = ExchangeOffice.Account;

namespace Presentation
{
    public class AdminWindowPresenter : IPresenter
    {
        private IKernel _kernel;
        private IAdminWindow _window;
        private ExecutorCommands _executorCommands;
        private bool InvalidDataFlag;
        public AdminWindowPresenter(IKernel kernel, IAdminWindow window, ExecutorCommands executorCommands)
        {
            _kernel = kernel;
            _window = window;
            _executorCommands = executorCommands;

            _window.Quit += QuitHandler;
            _window.InvalidData += InvalidData;
            _window.CallAboutWindow += CallingAboutWindow;
            _window.UpdateRate += () => UpdateRate(_window.ContributedCurrency, _window.TargetCurrency, _window.Rate);
            _executorCommands.UpdateRateEvent = UpdatedRateHandler;
            
        }
        
        private void UpdateRate(Currency ContributedCurrency, Currency TargetCurrency, decimal amount)
        {   
            var updateCommand = new CurrencyExchangeUpdateCommand(_executorCommands,ContributedCurrency,TargetCurrency,amount);
            if (!InvalidDataFlag)
            {
                if (Account.Instance.SendCommand(updateCommand)) return;
                _kernel.Get<DialogWindowPresenter>().SendMessage("Invalid command.");
            }
            InvalidDataFlag = false;
        }
        
        private void QuitHandler()
        {
            _window.Close();
            _kernel.Get<LoginWindowPresenter>().Run();
        }

        private void CallingAboutWindow()
        {
            _kernel.Get<AboutWindowPresenter>().Run();
        }
        
        private void UpdatedRateHandler(object sender, ServiceEventArgs<CurrencyExchange> e)
        {
            _kernel.Get<DialogWindowPresenter>().SendMessage(e.Message);
        }
        
        private void InvalidData()
        {
            InvalidDataFlag = true;
            _kernel.Get<DialogWindowPresenter>().SendMessage("Invalid data.");
        }
        
        public void Run()
        {
            _window.Show();
        }
    }
}
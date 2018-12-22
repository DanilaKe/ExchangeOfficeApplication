using System.Text;
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
            var Result = new StringBuilder();
            Result.Append($"{e.Result[0]?.ContributedCurrency} - {e.Result[0]?.TargetCurrency} : {e.Result[0]?.Rate}\n");
            Result.Append($"{e.Result[1]?.ContributedCurrency} - {e.Result[1]?.TargetCurrency} : {e.Result[1]?.Rate}\n");
            Result.Append(e.Message);
            _kernel.Get<DialogWindowPresenter>().SendMessage(Result.ToString());
        }
        
        private void InvalidData()
        {
            InvalidDataFlag = true;
            _kernel.Get<DialogWindowPresenter>().SendMessage("Invalid data.");
        }
        
        public void SetAdminName(string name)
        {
            _window.AdminName = name;
        }
        
        public void Run()
        {
            _window.Show();
        }
    }
}
using System;
using ExchangeOffice;
using GraphicalUserInterface;
using Gtk;
using Ninject;

namespace BSUTPApplication
{
    namespace BankApplication
    {
        class EntryPoint
        {
            static void Main(string[] args)
            {
                try
                {
                    var kernel = new StandardKernel();
                    kernel.Bind<IAdminWindow>().To<AdminWindow>();
                    kernel.Bind<IAboutWindow>().To<AboutWindow>();
                    kernel.Bind<ILoginWindow>().To<LoginWindow>();
                    kernel.Bind<IDialogWindow>().To<DialogWindow>();
                    kernel.Bind<ICashierWindow>().To<CashierWindow>();
                    kernel.Bind<AboutWindowPresenter>().ToSelf();
                    kernel.Bind<AdminWindowPresenter>().ToSelf();
                    kernel.Bind<LoginWindowPresenter>().ToSelf();
                    kernel.Bind<DialogWindow>().ToSelf();
                    kernel.Bind<CashierWindow>().ToSelf();

                    kernel.Get<LoginWindowPresenter>().Run();
                    Application.Run();
                    /*  ExecutorCommands exchangeOffice = new ExchangeOffice.ExchangeOffice();
                      App.getInstance().SetExecutorCommands(exchangeOffice);
                      App.getInstance().Run();*/
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
        }
    }

}
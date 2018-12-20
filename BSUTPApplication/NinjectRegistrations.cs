using BSUTPApplication.GraphicalUserInterface;
using ExchangeOffice;
using Ninject.Modules;
using Presentation;
using Presentation.WindowInterfaces;

namespace BSUTPApplication
{
    /// <summary>
    /// Class NinjectRegistrations
    /// </summary>
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAdminWindow>().To<AdminWindow>();
            Bind<IAboutWindow>().To<AboutWindow>();
            Bind<ILoginWindow>().To<LoginWindow>();
            Bind<IDialogWindow>().To<DialogWindow>();
            Bind<ICashierWindow>().To<CashierWindow>();
            Bind<AboutWindowPresenter>().ToSelf();
            Bind<AdminWindowPresenter>().ToSelf();
            Bind<LoginWindowPresenter>().ToSelf();
            Bind<DialogWindowPresenter>().ToSelf();
            Bind<CashierWindowPresenter>().ToSelf();
            Bind<ExecutorCommands>().To<ExchangeOffice.ExchangeOffice>().InSingletonScope();
        }
    }
}
using System;
using ExchangeOffice;
using Gdk;
using GraphicalUserInterface;
using Gtk;
using Ninject;

namespace BSUTPApplication
{
    namespace BankApplication
    {
        class EntryPoint
        {
            static void Main(string[] args) // сделать инициализацию кернела в отдельном классе,
            {
                var registrations = new NinjectRegistrations();
                var kernel = new StandardKernel(registrations);

                kernel.Get<LoginWindowPresenter>().Run();
                Application.Run();
            }
        
        }
    }

}
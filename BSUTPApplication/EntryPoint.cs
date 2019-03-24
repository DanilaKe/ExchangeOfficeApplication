using Gtk;
using Ninject;
using Presentation;

namespace BSUTPApplication
{
    internal static class EntryPoint
    {
        private static void Main()
        {
            var registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            kernel.Get<LoginWindowPresenter>().Run();
            Application.Run();
        }
    
    }
    

}

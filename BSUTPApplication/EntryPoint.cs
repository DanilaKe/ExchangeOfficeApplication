using Gtk;
using Ninject;
using Presentation;

namespace BSUTPApplication
{
    /// <summary>
    /// Class EntryPoint
    /// 
    /// </summary>
    internal static class EntryPoint
    {
        /// <summary>
        /// Method Main.
        /// Entry point.
        /// </summary>
        private static void Main()
        {
            var registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            kernel.Get<LoginWindowPresenter>().Run();
            Application.Run();
        }
    
    }
    

}
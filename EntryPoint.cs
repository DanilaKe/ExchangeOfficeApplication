using System;
using GraphicalUserInterface;

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
                    App app = new App();
                    app.Run();
                    
                    // TODO
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
        }
    }

}
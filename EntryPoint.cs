using System;
using ExchangeOffice;
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
                    ExecutorCommands exchangeOffice = new ExchangeOffice.ExchangeOffice();
                    App.getInstance().SetExecutorCommands(exchangeOffice);
                    App.getInstance().Run();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
        }
    }

}
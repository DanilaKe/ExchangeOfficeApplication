using System;
using ExchangeOfficeApplication.GUI;

namespace ExchangeOfficeApplication
{
    namespace BankApplication
    {
        class EntryPoint
        {
            static void Main(string[] args)
            {
                try
                {
                    new LoginWindow();
                    
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
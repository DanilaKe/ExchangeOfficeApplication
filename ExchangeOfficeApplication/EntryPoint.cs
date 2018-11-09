﻿using System;
using ExchangeOfficeApplication.GUI;
using Gtk;

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
                    new Login();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
        }
    }

}
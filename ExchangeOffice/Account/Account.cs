using System;

namespace ExchangeOffice
{
    public abstract class Account
    {
        private static Account _instance;
        public static Account Instance
        {
            get => _instance ?? (_instance = new UnauthenticatedUser());

            protected set => _instance = value;
        }

        public abstract bool SendCommand(Command command);
        
    }
    
}
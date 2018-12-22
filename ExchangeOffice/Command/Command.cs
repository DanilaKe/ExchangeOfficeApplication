using System;

namespace ExchangeOffice
{
    public abstract class Command
    {
        protected ExecutorCommands _executorCommands;

        protected Command(ExecutorCommands executorCommands)
        {
            _executorCommands = executorCommands;
        }

        internal abstract void Execute();
    }
}
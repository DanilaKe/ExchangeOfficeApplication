using System;

namespace ExchangeOffice
{
    public interface IEventsCommands
    {
        event ServiceStateHandler LoginEvent;
    }
}
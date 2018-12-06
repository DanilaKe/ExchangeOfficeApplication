using System;

namespace ExchangeOffice
{
    public interface IEventsCommands
    {
        void CallEvent(ServiceEventArgs e, ServiceStateHandler handler);
        event ServiceStateHandler LoginEvent;
    }
}
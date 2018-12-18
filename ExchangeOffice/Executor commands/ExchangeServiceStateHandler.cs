using DataSourceAccess;

namespace ExchangeOffice
{
    public delegate void ServiceStateHandler(object sender, ServiceEventArgs e);

    public class ServiceEventArgs
    {
        public bool Status { get; set; }

        public string[] Message { get; set; }

        public ServiceEventArgs(bool status,params string[] message)
        {
            Status = status;
            Message = message;
        }
    }
}
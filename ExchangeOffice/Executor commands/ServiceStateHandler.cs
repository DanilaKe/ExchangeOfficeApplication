namespace ExchangeOffice
{
    public delegate void ServiceStateHandler(object sender, ServiceEventArgs e);

    public class ServiceEventArgs
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public ServiceEventArgs(bool _status,string _message)
        {
            Status = _status;
            Message = _message;
        }
    }
}
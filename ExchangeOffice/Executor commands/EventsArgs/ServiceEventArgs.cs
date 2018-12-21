using System.Collections.Generic;

namespace ExchangeOffice
{
    public class ServiceEventArgs<T>
    {
        public List<T> Result { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
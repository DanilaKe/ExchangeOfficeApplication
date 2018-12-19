namespace ExchangeOffice
{
    public interface IServiceEventArgs
    {
        bool Status { get; set; }
        string Message { get; set; }
    }
}
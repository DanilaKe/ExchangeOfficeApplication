using DataSourceAccess;

namespace ExchangeOffice
{
    public abstract class ExecutorCommands
    {
        internal abstract void Exchange(int customerID, Currency TargetCurrency, Currency ContributedCurrency,
            decimal amount);
        internal abstract void ViewingHistory(int customerID);
        internal abstract void Login(string login, string password, bool adminFlag);

        internal abstract void CurrenceExchangeUpdate(Currency TargetCurrency, Currency ContributedCurrency,
            decimal newPurchaseRate,
            decimal newSaleRate);
        internal abstract void GetLog();
    }
}
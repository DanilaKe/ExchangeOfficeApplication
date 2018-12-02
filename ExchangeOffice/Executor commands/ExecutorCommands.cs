using DataSourceAccess;

namespace ExchangeOffice
{
    public abstract class ExecutorCommands
    {
        internal void Exchange(int customerID, Currency TargetCurrency, Currency ContributedCurrency, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        internal void ViewingHistory(int customerID)
        {
            throw new System.NotImplementedException();
        }

        internal virtual void Login(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        internal void CurrenceExchangeUpdate(Currency TargetCurrency, Currency ContributedCurrency, decimal newPurchaseRate,
            decimal newSaleRate)
        {
            throw new System.NotImplementedException();
        }

        internal void GetLog()
        {
            throw new System.NotImplementedException();
        }
    }
}
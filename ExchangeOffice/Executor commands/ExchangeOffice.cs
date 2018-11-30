using ExchangeOffice.Service;
using Executor_Commands;

namespace ExchangeOffice
{
    public class ExchangeOffice : ExecutorCommands, IEventsCommands
    {
        internal void Exchange(int customerID, Currency targetCurrency, Currency contributedCurrency, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        internal void ViewingHistory(int customerID)
        {
            throw new System.NotImplementedException();
        }

        internal override void Login(string login, string password)
        {
            new LoginService();
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
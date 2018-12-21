using System;
using DataSourceAccess;

namespace ExchangeOffice
{
    public abstract class ExecutorCommands
    {
        internal abstract void Exchange(string name, Currency TargetCurrency, Currency ContributedCurrency,
            decimal amount);
        internal abstract void ViewingHistory(int customerID);
        internal abstract void Login(string login, string password, bool adminFlag);

        internal abstract void CurrencyExchangeUpdate(Currency TargetCurrency, Currency ContributedCurrency,
            decimal newPurchaseRate,
            decimal newSaleRate);
        internal abstract void GetLog();

        internal abstract void GetCurrencyRate();
        
        internal abstract void CallEvent<T>(ServiceEventArgs<T> e, Action<object,ServiceEventArgs<T>> handler);
        public Action<object,ServiceEventArgs<DataSourceAccess.Account>> LoginEvent;
        public Action<object,ServiceEventArgs<Exchange>> ExchangeEvent;
        public Action<object, ServiceEventArgs<CurrencyExchange>> CurrencyRateEvent;
    }
}
using System;
using System.Globalization;
using System.Text;
using DataSourceAccess;

namespace Presentation
{
    public static class StringExtension
    {
        public static string GetReportOnOperation(this Exchange Exchange)
        {
            var exchangeResult = new StringBuilder(BillTemplate); 
            exchangeResult.Replace("%Date%",DateTime.Now.ToString(CultureInfo.InvariantCulture));
            exchangeResult.Replace("%Name%", Exchange.Customer.Name);
            exchangeResult.Replace("%AccountNumber%", Exchange.Customer.CustomerId.ToString());
            exchangeResult.Replace("%ContributedCurrency%",
                Enum.GetName(typeof(Currency),Exchange.CurrencyExchange.ContributedCurrency));
            exchangeResult.Replace("%TargetCurrency%",
                Enum.GetName(typeof(Currency),Exchange.CurrencyExchange.TargetCurrency));
            exchangeResult.Replace("%ExchangeRates%",
                Exchange.CurrencyExchange.Rate.ToString(CultureInfo.InvariantCulture));
            exchangeResult.Replace("%ContributedAmount%",
                Exchange.ContributedAmount.ToString(CultureInfo.InvariantCulture));
            exchangeResult.Replace("%IssuedAmount%",
                Exchange.IssuedAmount.ToString(CultureInfo.InvariantCulture));
            exchangeResult.Replace("%TodayLimit%",
                Exchange.Customer.DailyLimit.ToString(CultureInfo.InvariantCulture));
            return exchangeResult.ToString();
        }

        private const string BillTemplate =
@"Дата : %Date%
Счет : %AccountNumber%

Имя : %Name%

Валюта операции : %ContributedCurrency%
Целевая валюта : %TargetCurrency%
Курс : %ExchangeRates%
Внесенная сумма : %ContributedAmount%
Полученная сумма : %IssuedAmount%

Сегодняшний лимит : %TodayLimit%";
    }
}
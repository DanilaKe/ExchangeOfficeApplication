using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Ninject;

namespace DataSourceAccess
{
    public class CurrencyRatePage
    {
        private IKernel _kernel;
        Dictionary<int,decimal> CurrencyRate;
        private HtmlDocument htmlDocument;
        private HtmlDocument rubHtmlDocument;
        public CurrencyRatePage(IKernel kernel)
        {
            _kernel = kernel;
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            var page = webClient.DownloadString("https://myfin.by/currency/minsk");
            var rubPage = webClient.DownloadString("https://myfin.by/currency/rub");
            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(page);
            rubHtmlDocument = new HtmlDocument();
            rubHtmlDocument.LoadHtml(rubPage);
        }

        public void UpdateCurrencyExchange()
        {
            CurrencyRate = new Dictionary<int, decimal>()
            {
                {1,decimal.Round(decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[6]").InnerText.Replace(".",","))/100,4)},
                {2,decimal.Round(1/decimal.Parse(rubHtmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[1]/td[6]").InnerText.Replace(".",",")),4)},
                {3,decimal.Round(1/decimal.Parse(rubHtmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[1]/td[4]").InnerText.Replace(".",",")),4)},
                {4,decimal.Round(100/decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[6]").InnerText.Replace(".",",")),4)},
                {5,decimal.Round(1/decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[2]").InnerText.Replace(".",",")),4)},
                {6,decimal.Round(1/decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[4]").InnerText.Replace(".",",")),4)},
                {7,decimal.Round(decimal.Parse(rubHtmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[1]/td[6]").InnerText.Replace(".",",")),4)},
                {8,decimal.Round(decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[2]").InnerText.Replace(".",",")),4)},
                {9,decimal.Round(1/decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[8]").InnerText.Replace(".",",")),4)},
                {10,decimal.Round(decimal.Parse(rubHtmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[1]/td[4]").InnerText.Replace(".",",")),4)},
                {11,decimal.Round(decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[4]").InnerText.Replace(".",",")),4)},
                {12,decimal.Round(decimal.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"currency_tbody\"]/tr[2]/td[8]").InnerText.Replace(".",",")),4)}
                };
            var k = 1;
            var date = _kernel.Get<UnitOfWork>().Dates.GetList().Last();
            var db = _kernel.Get<UnitOfWork>().CurrencyExchanges;
            for (var i = 1; i <= 4; i++)
            {
                for (var j = 1; j <= 4; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    db.Create(new CurrencyExchange(){ContributedCurrency = (Currency)i,TargetCurrency = (Currency)j,Rate = CurrencyRate[k],DateId = date.DateId});
                    k++;
                }
            }
            _kernel.Get<UnitOfWork>().Save();
        }
    }
}
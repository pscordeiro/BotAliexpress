using OpenQA.Selenium;
using System;
using System.Threading;

namespace BotAliexpress
{
    public class Bot : Atributos
    {
        #region CarregaURL

        protected static void CarregaUrl(string url)
        {
            chromeDriver.Navigate().GoToUrl(url);           
        }
        #endregion

        #region ValidaUrl
        protected static bool ValidaUrl(string url)
        {
            while(chromeDriver.Url != url)
            {
                continue;
            }
            return true;
        }
        #endregion

        #region EfetuaCompra
        protected static void EfetuaCompra(string valorInicial, DateTime horarioInicio, bool valid)
        {
            while (!valid)
            {
                while (DateTime.Parse(DateTime.Now.ToString("HH:mm:ss")) >= horarioInicio)
                {
                    //chromeDriver.Navigate().Refresh();

                    html.LoadHtml(chromeDriver.PageSource);

                    try
                    {
                       string validacaoPagamento = html.DocumentNode.SelectSingleNode("//div[@class='pay-brief-info ']").InnerText;
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e);
                        SelecionaPagamento();
                    }

                    //Inserir o cupom e finalizar a compra
                    while (true)
                    {
                        //html.LoadHtml(chromeDriver.PageSource);
                        //valorInicial = html.DocumentNode.SelectSingleNode("//div[@class='total-price']").InnerText;
                        //Código do cupom de desconto
                        chromeDriver.FindElementByXPath("//div[@class='next-form-item-control']//input").SendKeys("30X3PRO");
                        Thread.Sleep(700);
                        chromeDriver.FindElementByXPath("//div[@class='next-form-item-control']//button").Click();
                        Thread.Sleep(500);
                        chromeDriver.FindElementByXPath("//div[@id='root']").Click();
                        Thread.Sleep(300);

                        //IWebElement element = firefoxDriver.FindElements(By.XPath("//div[@id='root']"));

                         valorInicial = "TotalUS $540.09";

                        html.LoadHtml(chromeDriver.PageSource);
                        string valorFinal = html.DocumentNode.SelectSingleNode("//div[@class='total-price']").InnerText;

                        //Verifica se o valor foi alterado
                        if (valorInicial != valorFinal)
                        {
                            break;
                        }
                    }
                    chromeDriver.FindElementByXPath("//div[@class='order-btn-holder']//button").Click();
                    valid = true;
                    break;
                }
            }
        }
        #endregion

        #region SelecionaPagamento
        private static void SelecionaPagamento()
        {
            html.LoadHtml(chromeDriver.PageSource);
            Thread.Sleep(600);
            chromeDriver.FindElementByXPath("//button[@class='next-btn next-medium next-btn-primary next-btn-text selected-payment-btn']").Click();                                                           
            Thread.Sleep(500);
            chromeDriver.FindElementByXPath("//div[@ae_object_value = 'select_payoption=BOLETO']").Click();
            Thread.Sleep(500);
            chromeDriver.FindElementByXPath("//div[@class='save']//button").Click();
            Thread.Sleep(500);
        }
        #endregion
    }
}

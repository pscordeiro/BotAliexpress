using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BotAliexpress
{
    public class Atributos
    {
        protected static readonly ChromeDriver chromeDriver = new ChromeDriver();
        protected static readonly IWebDriver firefoxDriver = new FirefoxDriver();
        public interface IWebElement : ISearchContext { }
        protected static readonly HtmlDocument html = new HtmlDocument();
    }
}

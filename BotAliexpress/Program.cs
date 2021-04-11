using System;

namespace BotAliexpress
{
    class Program : Bot
    {
        //Url do carrinho de compras da Aliexpress
        private const string url = "https://shoppingcart.aliexpress.com/orders.htm?aeOrderFrom=main_shopcart&availableProductShopcartIds=81006859721642";

        static void Main(string[] args)
        {
            CarregaUrl(url);
            
            //Bot setado para rodar apenas a partir das 21:00:00
            DateTime horarioInicio = DateTime.Parse("03:59:57");
            Console.WriteLine("Comprado as: " + DateTime.Now);

            bool valid = false;

            html.LoadHtml(chromeDriver.PageSource);

            string valorInicial = html.DocumentNode.SelectSingleNode("//div[@class='total-price']").InnerText;
            EfetuaCompra(valorInicial, horarioInicio, valid);

            Console.WriteLine("É NOIS QUE VOA BRUXO!!");
            Console.WriteLine("Comprado as: " + DateTime.Now);

        }
    }
}

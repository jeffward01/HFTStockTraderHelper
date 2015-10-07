using HFTStockTrader.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFTStockTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the best stock HFT ever!!!");
            Console.WriteLine("Please press enter to continue");
            Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Please enter the Stock Symbol you wish receive trade advice on");
            string mySearchStock = Console.ReadLine();

            StockServiceClass Service = new StockServiceClass();

            Service.getStockPrice(mySearchStock);
            Service.SaveStockData();
            Service.OutputStockData();
            Console.WriteLine("Please press enter to enter Advisor Mode....");
            Console.ReadLine();

            //Timer
            var timer = new System.Threading.Timer(
             e => Service.TradeAdvisor(mySearchStock),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(3));





            Console.ReadLine();

        }
        
    }
}

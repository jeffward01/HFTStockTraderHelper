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

            Stock myStock = Service.getStockPrice(mySearchStock);



            Console.WriteLine("Your asking price is: " + myStock.ask);

        }
        
    }
}

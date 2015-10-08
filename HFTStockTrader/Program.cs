using HFTStockTrader.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HFTStockTrader
{
    class Program
    {
        //Number of Stock count
        public static decimal numberOfStocks = 0;
        public static List<Stock> listeningStocks = new List<Stock>();
        public static List<Stock> listeningStocksStorage = new List<Stock>();
        public static List<StockComparison> stockComparisonList = new List<StockComparison>();
        public static string Line = "\n ----------------------------------------------";
        public static string Space = "        ";
        public static bool isListening = true;
       
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the best stock HFT ever!!!");
            Console.WriteLine("Please press enter to continue");
            Console.ReadLine();
            StockInformationSearch();
            EndSearchPrompt();



            /*

            

          

            Service.getStockInformation(mySearchStock);
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

    */



           

        }

        /*
        public static void enterListenMode(string message)
        {
            while (true)
            Console.WriteLine(message);
            string input = 


        }
        */

        public static void StockInformationSearch()
        {


            Console.Clear();
            StockServiceClass Service = new StockServiceClass();
            //Get number of stocks to listen to
            numberOfStocks = Service.getNumberOfStocks("Please enter in the number of stocks you would like to listen to", true, true);
            for (var i = 0; i < numberOfStocks; i++)
            {
                //Get the stock information for each stock you are listening to
                Console.WriteLine("Please enter the Stock Symbol you wish receive trade advice on");
                string mySearchStock = Console.ReadLine();
                Stock newStock = new Stock();
                newStock = Service.getStockInformation(mySearchStock);
                listeningStocks.Add(newStock);
                stockComparisonList.Add(new StockComparison
                {
                    current = newStock
                });
            }
            Console.Clear();
            //Output Chosen Stock Inforamtion to Screen
            foreach (Stock stock in listeningStocks)
            {
                Service.OutputStockData(stock);

            }

            EndSearchPrompt();
        }
        public static void StockListener()
        {


                var timer = new System.Threading.Timer(
                 e => GetCurrentStockPrice(),
                    isListening,
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(3));
            
           
        

         
            /*
            if (!isListening)
            {
                EndSearchPrompt();
            }
            */
            //Get current Price every 5 seconds

        }
        public static void GetCurrentStockPrice()
        {
            Console.Clear();
            var stockService = new StockServiceClass();

            foreach (var stockComparison in stockComparisonList)
            {
                stockComparison.previous = stockComparison.current;

                stockComparison.current = stockService.getStockInformation(stockComparison.current.symbol);

                // compare stockComparison.current.price to stockComparison.previous.price
                // show message advising BUY, SELL or KEEP

                string previousAsk = stockComparison.previous.ask;
                string currentAsk = stockComparison.current.ask;

                Console.WriteLine("The Previous price is: {0}  || The current Price is: {1}", previousAsk,currentAsk);

                try
                {
                    decimal previousPrice = Decimal.Parse(previousAsk);
                    decimal currentPrice = Decimal.Parse(currentAsk);
           
                if (previousPrice > currentPrice)
                {
                    Console.WriteLine("The price of {0} is falling.  You should BUY!  The Previous Price is: ${1}  || The Current Price is ${2}", stockComparison.current.symbol,previousAsk,currentAsk);
                    Console.WriteLine(" \n \n ");
                }
                else if (currentPrice > previousPrice)
                {
                    Console.WriteLine("The price of {0} is Rising!.  You should SELL!  The Previous Price is: ${1}  || The Current Price is ${2}", stockComparison.current.symbol, previousAsk, currentAsk);
                    Console.WriteLine(" \n \n ");
                }
                else
                {
                    Console.WriteLine("The price of {0} is Stagnent!.  You should HOLD!  The Previous Price is: ${1}  || The Current Price is ${2}", stockComparison.current.symbol, previousAsk, currentAsk);
                    Console.WriteLine(" \n \n ");
                }

                }
                catch (Exception)
                {
                    Console.WriteLine("Your Stock is not availble...");
                    Console.WriteLine("CATCH WAS THROWN -- The Previous price is: {0}  || The current Price is: {1}", previousAsk, currentAsk);
                }

            }
            Console.WriteLine(Line);
            Console.WriteLine("Press Enter to Exit Listen Mode");
            Console.ReadLine();
            isListening = false;
            return;
            /*
            string input = Console.ReadLine();
            if(input == null)
            {
                EndSearchPrompt();
                isListening = false;
               
            }
            else
            {
                EndSearchPrompt();
                isListening = false;
                
            }
            */
        }



        public static  void EndSearchPrompt()
        {
            Console.WriteLine(Line);
            Console.WriteLine(Space + "Please Press type 'Listen' to enter Listening Mode  || type 'exit' to exit || or type 'search' to search again'");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "listen":
                    isListening = true;
                    StockListener();
                    break;
                case "exit":
                    ExitProgramPrompt();
                    break;
                case "search":
                    StockInformationSearch();
                    break;
                default:
                    EndSearchPrompt();
                    break;
            }
          
        }
        public static void ExitProgramPrompt()
        {
            Console.WriteLine("Are you sure you want to exit?  (yes/no)");
            string input = Console.ReadLine().ToLower();

            switch(input)
            {
                case "yes":
                    Environment.Exit(0);
                    break;
                case "no":
                    EndSearchPrompt();
                    break;
                default:
                    Console.Clear();
                    ExitProgramPrompt();
                    break;
            }


        }
    }
}

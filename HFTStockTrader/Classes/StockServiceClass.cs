using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HFTStockTrader.Classes
{
    class StockServiceClass
    {
        //Properties
        public decimal price1;
        public decimal price2;

        //Stock Properties
        public string mySymbol;
        public string myAsk;
        public string myBid;
        public string myLastTrade;
        public string myLow;
        public string myHigh;
        public string my52weekLow;
        public string my52weekHigh;
        public string myVolume;
        public string myOpen;
        public string myClose;

        

        //Methods
        public decimal getNumberOfStocks(string message, bool isPostive = true, bool NonZero = true)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);

                    string input = Console.ReadLine();

                    decimal returnValue = decimal.Parse(input);

                    if (isPostive == true && returnValue < 0)
                    {
                        Console.WriteLine("Please enter a positive number");

                        continue;
                    }
                    if (NonZero == false && returnValue == 0)
                    {
                        Console.WriteLine("Please enter a number other than 0");

                        continue;
                    }

                    if ((returnValue * 2 > Decimal.MaxValue) || (returnValue * 3 > Decimal.MaxValue))
                    {
                        Console.WriteLine("---------------- \n \n");
                        Console.WriteLine("Please enter a smaller number, dont be a hacker...");
                        continue;
                    }
                    return returnValue;
                }
                catch (ArgumentNullException e)
                {
                 
                    Console.WriteLine("Please enter a value");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a numerical value");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Please enter a reasonably sized number");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error reading this decimal");
                }
            }



        }

        public Stock getStockInformation(string SearchString)
        {
            if(SearchString == null || SearchString == "" )
            {
                Console.WriteLine("Please enter a a Proper Stock Symbol... Press Enter to return..");
                Console.ReadLine();
                return null;
            }

            //Call the API
            using (WebClient webClient = new WebClient())
            {
                //Grab Stock information from the API
                string json = webClient.DownloadString("https://www.enclout.com/api/v1/yahoo_finance/show.json?&auth_token=oDqPEYznPaG7ELs_YYz-&text=" + SearchString);

                //Create a list to store the stocks in
                List<Stock> myStocks = new List<Stock>();


                //Deserialize the JSON string into the Mystocks likst
                myStocks = JsonConvert.DeserializeObject<List<Stock>>(json);

                //Validation
                if (myStocks.Count >= 2)
                {
                    Console.WriteLine("Your count is more than 2");
                    Console.ReadLine();
                }

                //Declare 'stock' and grab first element from MyStocks
                Stock stock = myStocks.FirstOrDefault();

                //Assign Stock Information to string varibles to store them
                mySymbol = stock.symbol;
                myAsk = stock.ask;
                myBid = stock.ask;
                myLastTrade = stock.last_trade_date;
                myLow = stock.low;
                myHigh = stock.high;
                my52weekLow = stock.low_52_weeks;
                my52weekHigh = stock.high_52_weeks;
                myVolume = stock.volume;
                myOpen = stock.open;
                myClose = stock.close;
                


                return stock;
            }
        }
        public void SaveStockData()
        {
            price1 = Decimal.Parse(myAsk);
        }


        public void OutputStockData(Stock myStock)
        {

            Console.WriteLine("\n \n Your Symbol is: " + myStock.symbol);
            Console.WriteLine(myStock.symbol + " asking price is $" + myStock.ask);
            Console.WriteLine("The last Bid is: $" + myStock.bid + Environment.NewLine);
            Console.WriteLine("The Daily High for {2} is: ${0} and the daily low for {2} is: ${1} " + Environment.NewLine, myStock.high, myStock.low, myStock.symbol);
            Console.WriteLine("The 52 Week High is: ${0} and the 52 Week Low is: ${1}", myStock.high_52_weeks, myStock.low_52_weeks);
            Console.WriteLine("The Volume of {0} is {1}" + Environment.NewLine, myStock.symbol, myStock.volume);
            Console.WriteLine("\n \n ------ \n ");
        }

        public void TradeAdvisor(string OriginalSearch)
        {
            Console.Clear();
            getStockInformation(OriginalSearch);
            price2 = Decimal.Parse(myAsk);

            if(price1 > price2)
            {
                Console.WriteLine("Your stock is {0} and you paid ${1}", mySymbol, myAsk);
                Console.WriteLine("Stock Price is dropping, BUY!!!!! Foo!");
                Console.WriteLine("Your stock was: ${0} now it is: ${1}",price1,price2);

            }
            else if(price2 > price1 )
            {
                Console.WriteLine("Your stock is {0} and you paid ${1}", mySymbol, myAsk);
                Console.WriteLine("Stock Price is RAISING, SELL!!");
                Console.WriteLine("Your stock was: ${0} now it is: ${1}", price1, price2);
            }
            else
            {
                Console.WriteLine("Your stock is {0} and you paid ${1}", mySymbol, myAsk);
                Console.WriteLine("No change in stock price... Wait it out");
                Console.WriteLine("Your stock was: ${0} now it is: ${1}", price1, price2);
            }




        }
         

    }
}

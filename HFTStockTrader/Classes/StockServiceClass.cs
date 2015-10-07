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
        string mySymbol;
        string myAsk;
        string myBid;
        string myLastTrade;
        string myLow;
        string myHigh;
        string my52weekLow;
        string my52weekHigh;
        string myVolume;
        string myOpen;
        string myClose;


        //Methods
        public void getStockPrice(string SearchString)
        {
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
      
            }
        }
        public void SaveStockData()
        {
            price1 = Decimal.Parse(myAsk);
        }


        public void OutputStockData()
        {

            Console.WriteLine("\n \n Your Symbol is: " + mySymbol);
            Console.WriteLine(mySymbol + " asking price is $" + myAsk);
            Console.WriteLine("The last Bid is: $" + myBid + Environment.NewLine);
            Console.WriteLine("The Daily High for {2} is: ${0} and the daily low for {2} is: ${1} " + Environment.NewLine, myHigh, myLow, mySymbol);
            Console.WriteLine("The 52 Week High is: ${0} and the 52 Week Low is: ${1}", my52weekHigh, my52weekLow);
            Console.WriteLine("The Volume of {0} is {1}" + Environment.NewLine, mySymbol, myVolume);
        }

        public void TradeAdvisor(string OriginalSearch)
        {
            Console.Clear();
            getStockPrice(OriginalSearch);
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

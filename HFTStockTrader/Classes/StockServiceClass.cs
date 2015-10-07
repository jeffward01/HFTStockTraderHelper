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
        public int price1;
        public int price2;

        

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
                if(myStocks.Count >= 2)
                {
                    Console.WriteLine("Your count is more than 2");
                    Console.ReadLine();
                }

                //Declare 'stock' and grab first element from MyStocks
                Stock stock = myStocks.FirstOrDefault();

                string mySymbol = stock.symbol;
                string myAsk = stock.ask;
                string myBid = stock.ask;
                string myLastTrade = stock.last_trade_date;
                string myLow = stock.low;
                string myHigh = stock.high;
                string my52weekLow = stock.low_52_weeks;
                string my52weekHigh = stock.high_52_weeks;
                string myVolume = stock.volume;
                string myOpen = stock.open;
                string myClose = stock.close;
                

                Console.WriteLine("\n \n Your Symbol is: "+mySymbol);
                Console.WriteLine(mySymbol + " asking price is $" + myAsk);
                Console.WriteLine("The last Bid is: $"+ myBid + Environment.NewLine);
                Console.WriteLine("The Daily High for {2} is: ${0} and the daily low for {2} is: ${1} " + Environment.NewLine ,myHigh,myLow,mySymbol);
                Console.WriteLine("The 52 Week High is: ${0} and the 52 Week Low is: ${1}", my52weekHigh, my52weekLow);
                Console.WriteLine("The Volume of {0} is {1}" + Environment.NewLine, mySymbol,myVolume);
               


                /*

                //Instantcize Stock Information
                Stock myStock = new Stock();

                //Create a JObject 
                JObject o = JObject.Parse(json);

                //Assign Varibles
                myStock.symbol = o[0]["symbol"].ToString();
                myStock.ask = o["ask"].ToString();
                myStock.bid = o["bid"].ToString();
                myStock.last_trade_date = o["last_trade_date"].ToString();
                myStock.low = o["low"].ToString();
                myStock.high = o["high"].ToString();
                myStock.low_52_weeks = o["low_52_weeks"].ToString();
                myStock.high_52_weeks = o["high_52_weeks"].ToString();
                myStock.volume = o["volume"].ToString();
                myStock.open = o["open"].ToString();
                myStock.close = o["close"].ToString();


                price1 = Int32.Parse(myStock.ask);

                return myStock;

    */
              
            }
        }
    }
}

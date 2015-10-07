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
        public Stock getStockPrice(string SearchString)
        {
            //Call the API
            using (WebClient webClient = new WebClient())
            {
                //Grab Stock information from the API
                string json = webClient.DownloadString("https://www.enclout.com/api/v1/yahoo_finance/show.json?&auth_token=oDqPEYznPaG7ELs_YYz-&text=" + SearchString);
                Console.WriteLine("JSON: " + json);
                Console.ReadLine();

                //Instantcize Stock Information
                Stock myStock = new Stock();

                //Create a JObject 
                JObject o = JObject.Parse(json);

                //Assign Varibles
                myStock.symbol = o["symbol"].ToString();
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
              
            }
        }
    }
}

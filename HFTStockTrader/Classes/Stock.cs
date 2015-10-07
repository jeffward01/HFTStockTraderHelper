using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFTStockTrader.Classes
{
    class Stock
    {
        public string symbol { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string last_trade_date { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string low_52_weeks { get; set; }
        public string high_52_weeks { get; set; }
        public string volume { get; set; }
        public string open { get; set; }
        public string close { get; set; }

    }
}

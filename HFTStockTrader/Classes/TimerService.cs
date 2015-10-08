using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HFTStockTrader.Classes
{
    class TimerService
    {
        public static Timer timer = new Timer();

        public static void setTimer(int duration)
        {

            timer.Interval = duration;
            timer.Elapsed += OnTimedEvent;

            timer.AutoReset = true;



        }

       public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                Program.StockListener();

            }
            catch(Exception)
            {

                Console.WriteLine("An error as occured");
            }



        }
        public static void stopTimer()
        {
            timer.Stop();
            timer.Dispose();

        }
    }
}

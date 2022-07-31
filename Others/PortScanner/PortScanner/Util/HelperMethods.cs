using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace PortScanner.Util
{
   public static class HelperMethods
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void PauseForXSeconds(int secondsPaused)
        {
            secondsPaused = (int)TimeSpanUtil.ConvertMillisecondsToSeconds(secondsPaused);
            System.Threading.Thread.Sleep(secondsPaused);
        }

        public static void PauseForXMinutes(int minutesPaused)
        {
            minutesPaused = (int)TimeSpanUtil.ConvertMinutesToMilliseconds(minutesPaused);
            System.Threading.Thread.Sleep(minutesPaused);
        }

        public static void LogErrors(Exception ex)
        {
            Logger.Debug(ex.Message);
            Logger.Debug(ex.StackTrace);
            Logger.Debug(ex.InnerException);
        }

    }
}

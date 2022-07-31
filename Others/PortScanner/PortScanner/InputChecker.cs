using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PortScanner
{
    static class InputChecker
    {
        // Check that a hostname string is valid
        public static bool IsValidHostname(string hostname)
        {
            return hostname != "";
        }

        // Check that a port is valid - returns -1 if port is invalid
        public static int ParsePort(string portString)
        {
            int port;

            try
            {
                port = Int32.Parse(portString);
            }
            // If any exception occurs, the string was not a proper port
            catch (Exception)
            {
                return -1;
            }

            if (port < 1 || port > 65535)
            {
                return -1;
            }

            return port;
        }

        // Check that timeout combobox user input is valid...
        // Accepted formats: [time] ms, [time]ms, [time]
        public static int ParseTimeout(string timeoutString)
        {
            // The regex that is used for matching the input against
            var regex = new Regex(@"^\d*\s*(ms)?$");
            
            // Try matching the user input
            if (!regex.IsMatch(timeoutString))
            {
                return -1;
            }

            // Slice off the "ms" part of the string
            timeoutString = Regex.Match(timeoutString, @"\d+").Value;
            int timeout = Int32.Parse(timeoutString);

            // Doesn't work too well with a very short timeout period
            if (timeout < 250 || timeout > 20000)
            {
                return -1;
            }

            return timeout;
        }
    }
}

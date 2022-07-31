using System;
using System.IO.Ports;
using System.Threading;

namespace Emulator
{
    public class Program
    {
        private static bool _continue;
        private static SerialPort _serialPort;

        public static void Main()
        {
            var stringComparer = StringComparer.OrdinalIgnoreCase;
            var readThread = new Thread(Read);

            _serialPort = new SerialPort
            {
                PortName = "COM1",
                ReadTimeout = 500,
                WriteTimeout = 500
            };

            _serialPort.Open();
            _continue = true;
            readThread.Start();

            while (_continue)
            {
                var x = ValueGenerator();
                var y = ValueGenerator();
                var z = ValueGenerator();
                var message = $"x:{x};y:{y};z:{z}";

                if (stringComparer.Equals("quit", message))
                {
                    _continue = false;
                }
                else
                {
                    _serialPort.WriteLine(message);
                    Thread.Sleep(200);
                }
            }

            readThread.Join();
            _serialPort.Close();
        }

        public static double ValueGenerator()
        {
            const int range = 1;
            var random = new Random();
            return random.NextDouble() * range;
        }

        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    var message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}

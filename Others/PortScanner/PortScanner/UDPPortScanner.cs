using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanner
{
    class UDPPortScanner: PortScannerBase
    {
        // The UDP client used for scanning a port
        private UdpClient udpClient;

        // Constructor - use base constructor
        public UDPPortScanner(): base()
        {
        }

        // TODO:
        public async override Task<bool> CheckOpenAsync(CancellationToken ct)
        {
            // We are using a UDP client to see whether the port is open or not
            // Therefore, the absence of a response means that the port is open
            // If there is any respone, it is closed
            using (udpClient = new UdpClient())
            {
                bool returnVal;
                try
                {
                    // Connect to the server
                    udpClient.Connect(Hostname, Port);

                    // Set the timeout
                    udpClient.Client.ReceiveTimeout = Timeout;

                    // Sends a message over UDP
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Are you open?");
                    udpClient.Send(sendBytes, sendBytes.Length);

                    // IPEndPoint object will allow us to read datagrams sent from any source.
                    // Port 0 means any available port
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                    // Asynchronously begin receiving
                    var result = udpClient.ReceiveAsync();
                    if (await Task.WhenAny(result, Task.Delay(Timeout, ct)) == result)
                    {
                        Console.WriteLine(Encoding.ASCII.GetString(result.Result.Buffer));
                        returnVal = false;
                    }
                    else
                    {
                        // There was no response, we will consider this port as open
                        returnVal = true;
                    }
                    udpClient.Close();
                    return returnVal;
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Error Code: " + e.ErrorCode);

                    switch (e.ErrorCode)
                    {
                        case 10054:
                            returnVal = false;
                            break;

                        case 11001:
                            returnVal = false;

                            // Display an error message on the main thread
                            MainWindow.ActiveForm.Invoke(new Action( () =>
                            {
                                MessageBox.Show(MainWindow.ActiveForm,
                                    "Hostname could not be resolved.",
                                    "Connection Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }));
                            break;
                        default:
                            returnVal = true;
                            break;
                    }
                }
                udpClient.Close();
                return returnVal;
            }
        }
    }
}

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServiceClient;

class Program
{
    private static void Main(string[] args)
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress? broadcast = GetHostIpAddress();

        byte[] sendBuf = Encoding.ASCII.GetBytes("Some Data");
        if (broadcast != null)
        {
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

            s.SendTo(sendBuf, ep);
        }

        Console.WriteLine("Message sent to the broadcast address");
    }

    private static IPAddress? GetHostIpAddress()
    {
        using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
        socket.Connect("8.8.8.8", 65530);
        IPEndPoint? endPoint = socket.LocalEndPoint as IPEndPoint;
        return endPoint?.Address;
    }

}
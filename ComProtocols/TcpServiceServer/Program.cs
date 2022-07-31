using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServiceServer;

public class TcpTimeServer
{

    private const int PortNum = 13;

    public static int Main(string[] args)
    {
        bool done = false;

        var listener = new TcpListener(IPAddress.Any, PortNum);

        listener.Start();

        while (!done)
        {
            Console.Write("Waiting for connection...");
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Connection accepted.");
            NetworkStream ns = client.GetStream();

            byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString(CultureInfo.InvariantCulture));

            try
            {
                ns.Write(byteTime, 0, byteTime.Length);
                ns.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        listener.Stop();

        return 0;
    }

}
using System.Net.Sockets;
using System.Text;

namespace TcpServiceClient;

public class TcpTimeClient
{
    private const int PortNum = 13;
    private const string HostName = "localhost";

    public static int Main(string[] args)
    {
        try
        {
            var client = new TcpClient(HostName, PortNum);

            NetworkStream ns = client.GetStream();

            byte[] bytes = new byte[1024];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);

            Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));

            client.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0;
    }
}
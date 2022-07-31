using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServiceServer;

public class UdpListener
{
    private const int ListenPort = 11000;

    private static void StartListener()
    {
        UdpClient listener = new UdpClient(ListenPort);
        IPEndPoint groupEp = new IPEndPoint(IPAddress.Any, ListenPort);

        try
        {
            while (true)
            {
                Console.WriteLine("Waiting for broadcast");
                byte[] bytes = listener.Receive(ref groupEp);

                Console.WriteLine($"Received broadcast from {groupEp} :");
                Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }

    public static void Main()
    {
        StartListener();
    }
}
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient;

//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/socket-code-examples
// State object for receiving data from remote device.  
public class StateObject
{
    // Client socket.  
    public Socket? WorkSocket = null;
    // Size of receive buffer.  
    public const int BufferSize = 256;
    // Receive buffer.  
    public byte[] Buffer = new byte[BufferSize];
    // Received data string.  
    public StringBuilder Sb = new StringBuilder();
}

public class AsynchronousClient
{
    // The port number for the remote device.  
    private const int Port = 11000;

    // ManualResetEvent instances signal completion.  
    private static readonly ManualResetEvent ConnectDone =
        new ManualResetEvent(false);
    private static readonly ManualResetEvent SendDone =
        new ManualResetEvent(false);
    private static readonly ManualResetEvent ReceiveDone =
        new ManualResetEvent(false);

    // The response from the remote device.  
    private static string _response = string.Empty;

    private static void StartClient()
    {
        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            // The name of the
            // remote device is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEp = new IPEndPoint(ipAddress, Port);

            // Create a TCP/IP socket.  
            Socket? client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            client.BeginConnect(remoteEp,
                new AsyncCallback(ConnectCallback), client);
            ConnectDone.WaitOne();

            // Send test data to the remote device.  
            Send(client, "This is a test<EOF>");
            SendDone.WaitOne();

            // Receive the response from the remote device.  
            Receive(client);
            ReceiveDone.WaitOne();

            // Write the response to the console.  
            Console.WriteLine("Response received : {0}", _response);

            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket? client = (Socket)ar.AsyncState!;

            // Complete the connection.  
            client?.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint);

            // Signal that the connection has been made.  
            ConnectDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void Receive(Socket? client)
    {
        try
        {
            // Create the state object.  
            StateObject state = new StateObject();
            state.WorkSocket = client;

            // Begin receiving the data from the remote device.  
            client?.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket
            // from the asynchronous state object.  
            StateObject? state = (StateObject)ar.AsyncState!;
            Socket? client = state?.WorkSocket;

            // Read data from the remote device.  
            if (client != null)
            {
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state?.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state?.Buffer!, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state != null && state.Sb.Length > 1)
                    {
                        _response = state.Sb.ToString();
                    }
                    // Signal that all bytes have been received.  
                    ReceiveDone.Set();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void Send(Socket? client, string data)
    {
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.  
        client?.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    private static void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket? client = (Socket)ar.AsyncState!;

            // Complete sending the data to the remote device.  
            {
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            }

            // Signal that all bytes have been sent.  
            SendDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static int Main(string[] args)
    {
        StartClient();
        return 0;
    }
}
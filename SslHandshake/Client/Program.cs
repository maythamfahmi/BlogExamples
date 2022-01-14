namespace Client
{
    public class Program
    {
        public static void Main()
        {
            StartClient();
        }

        public static void StartClient()
        {
            string serverCertificateName = "localhost";
            string machineName = "localhost";
            SslTcpClient.RunClient(machineName, serverCertificateName);
        }
    }
}

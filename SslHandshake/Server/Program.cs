using System.Security.Cryptography.X509Certificates;

namespace Server
{
    public class Program
    {
        public static Task[]? Tasks;
        public static async Task Main(string[] args)
        {
            var task = Task.Run(StartServer);
            await task.ContinueWith(HandleException, TaskContinuationOptions.OnlyOnFaulted);
        }

        private static void HandleException(Task task)
        {
            Console.WriteLine($"Task {task.Id} stopped");

            // Check task status
            if (Tasks != null)
                for (int i = 0; i < Tasks.Length; i++)
                {
                    Console.WriteLine($"Task {i} status = {Tasks[i].Status}");
                }

            // fFind and restart the task here
            if (Tasks != null && Tasks.Contains(task))
            {
                int index = Array.IndexOf(Tasks, task);
                Tasks[index] = Task.Run(() => { Thread.Sleep(1000); throw new Exception("BOOM"); })
                    .ContinueWith(HandleException, TaskContinuationOptions.OnlyOnFaulted);

                Console.WriteLine($"Task {Tasks[index].Id} started");
            }
        }

        public static void StartServer()
        {
            FileInfo certificate = new FileInfo(@"D:\certs\localhost.pfx");

            X509Certificate? fromStore = GetCertificateFromStore("CN=localhost");
            var export = fromStore?.Export(X509ContentType.Pfx);
            if (export != null) File.WriteAllBytes(certificate.FullName, export);

            X509Certificate? serverCertificate = X509Certificate.CreateFromCertFile(certificate.FullName);

            Console.WriteLine($"Certificate name {certificate.Name.Replace(".pfx", "")}");

            SslTcpServer.RunServer(serverCertificate);
        }

        private static X509Certificate2? GetCertificateFromStore(string certName)
        {
            X509Store store = new X509Store(StoreLocation.CurrentUser);

            try
            {
                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection certCollection = store.Certificates;
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                return signingCert.Count == 0 ? null : signingCert[0];
            }
            finally
            {
                store.Close();
            }
        }

    }

}

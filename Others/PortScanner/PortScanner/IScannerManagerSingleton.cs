using System.Threading;

namespace PortScanner
{
    internal interface IScannerManagerSingleton
    {
        void ExecuteOnceAsync(string hostname, int port, int timeout, ScannerManagerSingleton.ScanMode scanMode, MainWindow.ExecuteOnceAsyncCallback callback, CancellationToken ct);
        void ExecuteRangeAsync(string hostname, int portMin, int portMax, int timeout, ScannerManagerSingleton.ScanMode scanMode, MainWindow.ExecuteOnceAsyncCallback callback, CancellationToken ct);
    }
}
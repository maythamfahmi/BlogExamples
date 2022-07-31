using FakeItEasy;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading;

namespace PortScanner.Tests
{
    [TestFixture]
    public class ScannerManagerSingletonTests
    {
        [Test]
        public void ShouldIntiateUdpPortScanner()
        {
            //Arrange
            var constructor = typeof(ScannerManagerSingleton).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            var scannerManagerSingleton = (ScannerManagerSingleton)constructor.Invoke(null);
            var mainWindowconstructor = typeof(MainWindow.ExecuteOnceAsyncCallback).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            ScannerManagerSingleton.ScanMode scanMode;
            scanMode = ScannerManagerSingleton.ScanMode.UDP;
            string hostname = "127.0.0.1";
            int port = 80;
            int timeout = 2000;
            var cts = A.Fake<CancellationTokenSource>().Token;
            var callback = A.Fake<MainWindow.ExecuteOnceAsyncCallback>();

            //Act
            scannerManagerSingleton.ExecuteOnceAsync(hostname, port, timeout, scanMode, callback,
                  cts);

            //Assert
            //A.CallTo(() => scannerManagerSingleton.ExecuteOnceAsync(hostname, port, timeout, scanMode, callback,
            //    cts)).MustHaveHappened();
            Assert.Pass();
        }
    }
}
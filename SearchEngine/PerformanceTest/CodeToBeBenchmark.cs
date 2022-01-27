using System.Security.Cryptography;

namespace PerformanceTest
{
    public class CodeToBeBenchmark
    {
        private const int N = 10000;
        private readonly byte[] _data;

        private readonly SHA512 _sha512 = SHA512.Create();
        private readonly MD5 _md5 = MD5.Create();

        public CodeToBeBenchmark()
        {
            _data = new byte[N];
            new Random(42).NextBytes(_data);
        }

        public byte[] Sha512() => _sha512.ComputeHash(_data);

        public byte[] Md5() => _md5.ComputeHash(_data);
    }

}

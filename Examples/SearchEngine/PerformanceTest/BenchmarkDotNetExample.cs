using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PerformanceTest
{
    public class BenchmarkDotNetExample
    {
        private readonly CodeToBeBenchmark _code = new CodeToBeBenchmark();

        [Benchmark]
        public byte[] Sha512() => _code.Sha512();

        [Benchmark]
        public byte[] Md5() => _code.Md5();

        public static void Run()
        {
            var summary = BenchmarkRunner.Run<BenchmarkDotNetExample>();
        }
    }

}
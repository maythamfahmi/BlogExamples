using System.Diagnostics;

namespace PerformanceTest;

public class BenchmarkNativeExample
{
    private readonly CodeToBeBenchmark _code = new CodeToBeBenchmark();

    public byte[] Sha512() => _code.Sha512();

    public byte[] Md5() => _code.Md5();

    public static void Run()
    {
        BenchmarkNativeExample example = new BenchmarkNativeExample();
        example.BenchmarkConcept();
    }

public void BenchmarkConcept()
{
    int tests = 1000;

    Console.WriteLine("| Method |     Mean |");
    Console.WriteLine("|------- |---------:|");

    Stopwatch stopwatch = new Stopwatch();
    //warm up
    Sha512();

    stopwatch.Start();
    for (int i = 0; i < tests; i++)
    {
        Sha512();
    }
    stopwatch.Stop();

    var result2 = (double)stopwatch.ElapsedMicroSeconds() / tests;
    Console.WriteLine($"| Sha512 | {result2} us|");

    //warm up
    Md5();
    stopwatch.Restart();

    stopwatch.Start();
    for (int i = 0; i < tests; i++)
    {
        Md5();
    }
    stopwatch.Stop();

    var result1 = (double)stopwatch.ElapsedMicroSeconds() / tests;

    Console.WriteLine($"| Md5    | {result1} us|");
}

}

public static class Utility
{
    public static long ElapsedMicroSeconds(this Stopwatch watch)
    {
        return watch.ElapsedTicks * 1000000 / Stopwatch.Frequency;
    }
}
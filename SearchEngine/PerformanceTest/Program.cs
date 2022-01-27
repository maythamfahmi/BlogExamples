using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;

namespace PerformanceTest;

public class SearchBenchmarkTest
{
    private readonly SE1_done.Program _program1;
    private readonly SE2_done.Program _program2;
    private readonly SE3_done.SearchService _program3;
    private readonly string folder = $"./data/search-data-L.txt";

    public SearchBenchmarkTest()
    {
        _program1 = new SE1_done.Program();
        _program2 = new SE2_done.Program();
        _program3 = new SE3_done.SearchService();
        CreateData1();
        CreateData2();
        CreateData3();
    }

    public void CreateData1()
    {
        _program1.CreateDataStructure(folder);
    }

    public void CreateData2()
    {
        _program2.CreateDataStructure(folder);
    }

    public void CreateData3()
    {
        _program3.CreateDataStructure(folder);
    }

    [Benchmark]
    public void SearchForWordInList()
    {
        var result = _program1.FindWord("test");
    }

    [Benchmark]
    public void SearchForWordInDict()
    {
        var result = _program2.FindWord("test");
    }

    [Benchmark]
    public void SearchForWordInDictLevenstein()
    {
        var result = _program3.FindWord("tset");
    }

    public static void Main(string[] args)
    {
        BenchmarkWithBenchmarkDotNet();
    }


    public static void BenchmarkWithBenchmarkDotNet()
    {
        var summary = BenchmarkRunner.Run<SearchBenchmarkTest>();
    }

    public static void BenchmarkConcept()
    {
        Stopwatch time = new Stopwatch();
        int tests = 1000000;

        //warm up
        CreateHash(0);

        time.Start();
        for (int i = 0; i < tests; i++)
        {
            CreateHash(i);
        }
        time.Stop();

        Console.WriteLine("It took: " + time.ElapsedMilliseconds + " mil. second for CreateHash");

        time = new Stopwatch();

        //warm up
        CreateHashSha512(0);

        time.Start();
        for (int i = 0; i < tests; i++)
        {
            CreateHashSha512(i);
        }
        time.Stop();

        Console.WriteLine("It took: " + time.ElapsedMilliseconds + " mil. second for CreateHashSha512");
    }

    public static string CreateHash(int val)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(val.ToString()));
        var sb = new StringBuilder(hash.Length * 2);

        foreach (var b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }

    public static string CreateHashSha512(int val)
    {
        using var sha1 = SHA512.Create();
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(val.ToString()));
        var sb = new StringBuilder(hash.Length * 2);

        foreach (var b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }

}
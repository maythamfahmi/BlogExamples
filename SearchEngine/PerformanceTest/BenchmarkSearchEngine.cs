using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace PerformanceTest;

public class BenchmarkSearchEngine
{
    private readonly SE1_done.SearchService _program1;
    private readonly SE2_done.SearchService _program2;
    private readonly SE3_done.SearchService _program3;
    private readonly string path = $"./data/search-data-L.txt";

    public BenchmarkSearchEngine()
    {
        _program1 = new SE1_done.SearchService(path);
        _program2 = new SE2_done.SearchService(path);
        _program3 = new SE3_done.SearchService(path);
    }

    [Benchmark]
    public void SearchForWordInList()
    {
        _program1.FindWord("test");
    }

    [Benchmark]
    public void SearchForWordInDict()
    {
        _program2.FindWord("test");
    }

    [Benchmark]
    public void SearchForWordInDictLevenstein()
    {
        _program3.FindWord("tset");
    }

    public static Summary Run()
    {
        return BenchmarkRunner.Run<BenchmarkSearchEngine>();
    }

}
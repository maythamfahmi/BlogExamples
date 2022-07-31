namespace LinqDotNet6;

public class ZipExample
{
    public static void Example()
    {
        string[] winners = { "John", "Peter", "Mick" };
        int[] rank = { 1, 3, 2 };
        int[] points = { 99, 95, 96 };

        IEnumerable<(string winner, int rank, int point)> zipped = winners.Zip(rank, points);

        foreach (var tuple in zipped.OrderBy(e => e.rank))
        {
            Console.WriteLine($"{tuple.rank} {tuple.winner} {tuple.point}");
        }
    }

}

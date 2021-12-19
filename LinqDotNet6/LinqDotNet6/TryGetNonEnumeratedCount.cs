namespace LinqDotNet6;

public class TryGetNonEnumeratedCount
{
    public static void Example()
    {
        var pair1 = new[]
        {
            "Man1",
            "Woman1",
        };

        var pair2 = new[]
        {
            "Man2",
            "Woman2",
        };

        var pair3 = new[]
        {
            "Man3",
            "Woman3",
        };

        IEnumerable<string> concatPairs = pair1.Concat(pair2).Concat(pair3);

        var countForce = concatPairs.Count();
        if (countForce > 0)
        {
            // do some stuff
            Console.WriteLine("Enforce enumeration to count");
            Console.WriteLine(countForce);
        }

        if (concatPairs.TryGetNonEnumeratedCount(out var count))
        {
            // do some stuff
            Console.WriteLine("Try to count with out enforcing enumeration");
            Console.WriteLine(count);
        }
    }
}
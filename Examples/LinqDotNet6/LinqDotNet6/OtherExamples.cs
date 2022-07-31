namespace LinqDotNet6;

public class OtherExamples
{
    public static void Example()
    {
        var data = new[]
        {
            "person1",
            "person2",
            "person3",
            "person4",
            "person5"
        };

        var getPerson3 = data.ElementAt(2); // forward take and count from index 0
        Console.WriteLine(getPerson3);
        var getPerson4 = data.ElementAt(^2); // revers take the second revers
        Console.WriteLine(getPerson4);
        Console.WriteLine();

        var get2PersonsAfterPerson2 = data.Skip(2).Take(2);
        foreach (var s in get2PersonsAfterPerson2)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine();
        // the above can be shorten to 
        var get2PersonsAfterPerson2New = data.Take(2..4);
        foreach (var s in get2PersonsAfterPerson2New)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine();
        // Another example
        var get3PersonsReversFromPerson5 = data.Take(^3..);
        foreach (var s in get3PersonsReversFromPerson5)
        {
            Console.WriteLine(s);
        }


    }
}

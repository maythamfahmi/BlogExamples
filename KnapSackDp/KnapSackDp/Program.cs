namespace KnapSackDp;

public class Program
{
public static void Main()
{
    var ks = new KnapSackDp(Config.RockData(), Config.MaxWeight);
    var calculate = ks.Calculate();

    if (calculate.Ordered == null) return;
    foreach (var data in calculate.Ordered)
    {
        Console.WriteLine(data.ToString());
    }

    if (calculate.Weights != null)
    {
        var sum = $"{calculate.Weights.Sum(e => e.Value),34:F}";
        Console.WriteLine(sum);
    }

    Console.WriteLine();

    var result = $"{calculate.Value,34:F}";
    Console.WriteLine(result);
}
}
namespace KnapSack;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new KnapSack();
        var result = calculator.Calculate(Data.RawMaterials(), Config.MaxWeight);
        Console.WriteLine($"Max bonus for {Config.MaxWeight} weight is: {result} money unit");

        var sumAllValues = Data.RawMaterials().Sum(e => e.Value);
        var difference = (decimal)sumAllValues - result;
        var loadWeight = Data.RawMaterials().Where(e => Math.Abs(e.Value - (double)difference) > 0).Sum(e => e.Weight);
        Console.WriteLine($"Load weight in Trolley {loadWeight}");
    }
}

public class KnapSack
{
    public decimal Calculate(IReadOnlyList<Data> data, int maxWeight)
    {
        var bonus = data.Select(e => e.Value).ToArray();
        var weights = data.Select(e => (double)e.Weight).ToArray();
        return (decimal)Calculate(maxWeight, weights, bonus, bonus.Length);
    }

    private static double Calculate(double weight, IReadOnlyList<double> weights, IReadOnlyList<double> values, int n)
    {
        var idx = n - 1;

        if (n <= 0 || weight <= 0.0) return 0;
        if (weights[idx] > weight)
        {
            return 0;
        }

        var a = values[idx] + Calculate(weight - weights[idx], weights, values, idx);
        var b = Calculate(weight, weights, values, idx);

        var result = Max(a, b);

        return result;
    }

    private static double Max(double a, double b)
    {
        return a > b ? a : b;
    }
}
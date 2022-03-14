//namespace KnapSack;

//public class ProgramX
//{
//    public static void MainX(string[] args)
//    {
//        var calculator = new TransportCalculator();
//        var result = calculator.CalculateHighestIncome(RawMaterial.RawMaterials(), Config.MaxWeight);
//        Console.WriteLine($"Max bonus for {Config.MaxWeight} weight is: {result} money unit");
//        Console.WriteLine($"Item you should not transport:");
//        foreach (var item in ExcludeRawMaterials(result))
//        {
//            Console.WriteLine($"{item.Id}");
//        }
//    }

//    public static IEnumerable<RawMaterial> ExcludeRawMaterials(decimal bonus)
//    {
//        var sum = (decimal)RawMaterial.RawMaterials().Sum(e => e.Bonus);
//        var bonusBase = (bonus - Config.BaseIncome);
//        var exclude = sum - bonusBase;
//        return RawMaterial.RawMaterials()
//            .Where(e => (decimal)e.Bonus == exclude);
//    }
//}

//public class TransportCalculator
//{
//    public decimal CalculateHighestIncome(List<RawMaterial> transactions, int blockSize)
//    {
//        var transactionFee = transactions.Select(e => e.Bonus).ToArray();
//        var transactionByteSize = transactions.Select(e => e.Weight).ToArray();
//        return Config.BaseIncome + (decimal)CalculateReward(blockSize, transactionByteSize, transactionFee, transactionFee.Length);
//    }

//    private static double CalculateReward(double w, IReadOnlyList<int> weights, IReadOnlyList<double> values, int n)
//    {
//        while (true)
//        {
//            if (n <= 0 || w <= 0.0) return 0;
//            if (weights[n - 1] > w)
//            {
//                n = n - 1;
//            }
//            else
//            {
//                var val1 = values[n - 1] + CalculateReward(w - weights[n - 1], weights, values, n - 1);
//                var val2 = CalculateReward(w, weights, values, n - 1);
//                return Max(val1, val2);
//            }
//        }
//    }

//    private static double Max(double a, double b)
//    {
//        return a > b ? a : b;
//    }
//}

//public class RawMaterial
//{
//    public int Id { get; set; }
//    public int Weight { get; set; }
//    public double Bonus { get; set; }

//    public RawMaterial(int id, int weight, double bonus)
//    {
//        Id = id;
//        Bonus = bonus;
//        Weight = weight;
//    }

//    public static List<RawMaterial> RawMaterials()
//    {
//        return new List<RawMaterial>()
//        {
//            new RawMaterial(1, 5724, 0.01774),
//            new RawMaterial(2, 9873, 0.03712),
//            new RawMaterial(3, 13492, 0.04614),
//            new RawMaterial(4, 7727, 0.03044),
//            new RawMaterial(5, 2924, 0.01064),
//            new RawMaterial(6, 1544, 0.005),
//            new RawMaterial(7, 7082, 0.02818),
//            new RawMaterial(8, 13960, 0.05082),
//            new RawMaterial(9, 6371, 0.02294),
//            new RawMaterial(10, 14380, 0.0532),
//            new RawMaterial(11, 19045, 0.05866),
//            new RawMaterial(12, 14057, 0.01372),
//            new RawMaterial(13, 7082, 0.02818),
//            new RawMaterial(14, 13960, 0.05082),
//            new RawMaterial(15, 6371, 0.02294),
//            new RawMaterial(16, 13380, 0.0532),
//            new RawMaterial(17, 19045, 0.05866),
//            new RawMaterial(18, 7057, 0.01272),
//            new RawMaterial(19, 19045, 0.05866),
//            new RawMaterial(20, 6057, 0.00372),
//        };
//    }
//}

//public static class Config
//{
//    public const int MaxWeight = 200000;
//    public const decimal BaseIncome = 5;
//}
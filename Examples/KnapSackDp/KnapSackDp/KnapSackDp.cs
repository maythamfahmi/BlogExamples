namespace KnapSackDp;

public class KnapSackDp
{
    private readonly IReadOnlyList<Data> _data;
    private readonly Result _result;

    public KnapSackDp(IReadOnlyList<Data> data, int maxWeight)
    {
        var bonus = data.Select(e => e.Value).ToArray();
        var weights = data.Select(e => e.Weight).ToArray();
        _data = data;
        _result = Calculate(maxWeight, weights, bonus, bonus.Length);
    }

    public Result Calculate()
    {
        return _result;
    }

    private Result Calculate(int weight, IReadOnlyList<int> weights, IReadOnlyList<double> values, int n)
    {
        int i;
        int w;
        double[,] matrix = new double[n + 1, weight + 1];

        for (i = 0; i <= n; i++)
        {
            for (w = 0; w <= weight; w++)
            {
                var idx = i - 1;

                if (i == 0 || w == 0)
                {
                    matrix[i, w] = 0;
                }
                else if (weights[idx] <= w)
                {
                    var a = values[idx] + matrix[idx, w - weights[idx]];
                    var b = matrix[idx, w];
                    matrix[i, w] = Max(a, b);
                }
                else
                {
                    matrix[i, w] = matrix[idx, w];
                }
            }
        }

        var result = new Result();
        double value = matrix[n, weight];
        result.Value = value;
        result.Weights = new List<Data>();

        w = weight;
        for (i = n; i > 0 && value > 0; i--)
        {
            if (w < 0 || Math.Abs(value - matrix[i - 1, w]) == 0)
            {
                continue;
            }

            var data = result.GetData(_data.ToList(), i);
            if (data != null)
            {
                result.Weights.Add(data);
            }

            value -= values[i - 1];
            w -= weights[i - 1];
        }

        return result;
    }

    private static double Max(double a, double b)
    {
        return a > b ? a : b;
    }
}
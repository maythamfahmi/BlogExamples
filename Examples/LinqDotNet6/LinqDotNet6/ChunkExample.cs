namespace LinqDotNet6;

public class ChunkExample
{
    public static void Example1()
    {
        var pairs = new[]
        {
            "Man1",
            "Woman1",
            "Man2",
            "Woman2",
            "Man3",
            "Woman3",
        };

        IEnumerable<string[]> chunk = pairs.Chunk(2);

        var list = chunk.ToList();
        for (int i = 0; i < list.Count(); i++)
        {
            Console.WriteLine($"List index {i} has");
            for (int j = 0; j < list[i].Count(); j++)
            {
                Console.WriteLine($"- Array index {j} has {list[i][j]}");
            }
        }
    }

    public static void Example2()
    {
        var sensor = new[]
        {
            1, 2, 3,
            4, 5, 6,
            7, 8, 9
        };

        var sensors = sensor.Chunk(3)
            .Select(item => new SensorData(item[0], item[1], item[2]))
            .ToList();

        foreach (var data in sensors)
        {
            Console.WriteLine(data.Calculate);
        }
    }

    public class SensorData
    {
        public SensorData(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Calculate => X + Y + Z;
    }

}

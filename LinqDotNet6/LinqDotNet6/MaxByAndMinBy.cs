namespace LinqDotNet6
{
    public class MaxByAndMinBy
    {
        public static void Example()
        {
            var gameWinners = new List<GameWinner>
            {
                new ("John", 1, 99),
                new ("Peter", 3, 95),
                new ("Mick", 2, 96)
            };

            var highestPoint = gameWinners.MaxBy(e => e.Point);
            var lowestPoint = gameWinners.MinBy(e => e.Point);

            Console.WriteLine($"{highestPoint?.Name} has highest point {highestPoint?.Point}");
            Console.WriteLine($"{lowestPoint?.Name} has highest point {lowestPoint?.Point}");
        }

        public class GameWinner
        {
            public GameWinner(string name, int rank, int point)
            {
                Name = name;
                Rank = rank;
                Point = point;
            }

            public string Name { get; set; }
            public int Rank { get; set; }
            public int Point { get; set; }
        }
    }
}

namespace KnapSack;

public class Data
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public double Value { get; set; }

    public Data(int id, string description, int weight, double value)
    {
        Id = id;
        Description = description;
        Value = value;
        Weight = weight;
    }

    public static List<Data> RawMaterials()
    {
        return new List<Data>
        {
            new Data(1, "", 5724, 17.74),
            new Data(2, "",9873, 37.12),
            new Data(3, "",13492, 46.14),
            new Data(4, "",7727, 30.44),
            new Data(5, "",2924, 10.64),
            new Data(6, "",1544, 5),
            new Data(7, "",7082, 28.18),
            new Data(8, "",13960, 50.82),
            new Data(9, "",6371, 22.94),
            new Data(10, "",14380, 53.2),
            new Data(11, "",19045, 58.66),
            new Data(12, "",14057, 13.72),
            new Data(13, "",7082, 28.18),
            new Data(14, "",13960, 50.82),
            new Data(15, "",6371, 22.94),
            new Data(16, "",13380, 53.2),
            new Data(17, "",19045, 58.66),
            new Data(18, "",7057, 12.72),
            new Data(19, "",19045, 58.66),
            new Data(20, "",6057, 3.72),
        };
    }
}
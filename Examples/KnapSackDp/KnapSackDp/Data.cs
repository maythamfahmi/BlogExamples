namespace KnapSackDp
{
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

        public override string ToString()
        {
            var result = $"{Id,-4}{Description,-10}{Weight,10}{Value,10:F}";
            return result;
        }
    }

public class Result
{
    public List<Data>? Weights { get; set; }
    public IOrderedEnumerable<Data>? Ordered => Weights?.OrderBy(e => e.Id);
    public double Value { get; set; }

    public Data? GetData(List<Data> data, int idx)
    {
        return data.Find(e => e.Id == idx);
    }
}
}

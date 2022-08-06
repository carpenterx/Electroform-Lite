namespace ElectroformLite.Domain.Models;

public class DataGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Type { get; set; }

    public List<int> Data { get; set; } = new();

    public DataGroup(DataGroupTemplate dataGroupTemplate, string name)
    {
        Name = name;
        Type = dataGroupTemplate.Type;
    }
}

namespace ElectroformLite.Domain.Models;

public class DataGroupTemplate
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Type { get; set; }

    public List<int> DataTemplates { get; set; } = new();
}

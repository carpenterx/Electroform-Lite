namespace ElectroformLite.Domain.Models;

public class DataGroupTemplate
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    //public List<int> DataTemplates { get; set; } = new();
    public ICollection<DataGroup> DataGroups { get; set; }

    public DataGroupTemplate(string name)
    {
        Name = name;
    }
}

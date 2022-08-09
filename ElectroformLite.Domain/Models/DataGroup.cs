namespace ElectroformLite.Domain.Models;

public class DataGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Type { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public List<int> Data { get; set; } = new();

    public DataGroup(DataGroupTemplate dataGroupTemplate, string name, List<int> data)
    {
        Name = name;
        Type = dataGroupTemplate.Type;
        Data = data;
    }
}

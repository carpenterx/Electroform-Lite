namespace ElectroformLite.Domain.Models;

public class DataGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<int> Data { get; set; }
}

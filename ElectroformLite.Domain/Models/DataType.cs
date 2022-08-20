namespace ElectroformLite.Domain.Models;

public class DataType
{
    public Guid Id { get; set; }

    public string Value { get; set; }

    public ICollection<DataTemplate> DataTemplates { get; set; }

    public DataType(string value)
    {
        Value = value;
    }
}

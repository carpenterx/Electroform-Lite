namespace ElectroformLite.Domain.Models;

public class DataGroupType
{
    public int Id { get; set; }

    public string Value { get; set; }

    public DataGroupType(string value)
    {
        Value = value;
    }
}

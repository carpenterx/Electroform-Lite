namespace ElectroformLite.Domain.Models;

public class DataType
{
    public int Id { get; set; }

    public string Value { get; set; }

    public DataType(string value)
    {
        Value = value;
    }
}

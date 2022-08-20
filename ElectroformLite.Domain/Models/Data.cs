namespace ElectroformLite.Domain.Models;

public class Data
{
    public Guid Id { get; set; }

    public string Value { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Data(string value)
    {
        Value = value;
    }
}

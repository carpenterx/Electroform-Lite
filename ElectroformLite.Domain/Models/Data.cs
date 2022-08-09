namespace ElectroformLite.Domain.Models;

public class Data
{
    public int Id { get; set; }

    public string Placeholder { get; set; }

    public string Value { get; set; }

    public int Type { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Data(DataTemplate dataTemplate, string value)
    {
        Placeholder = dataTemplate.Placeholder;
        Value = value;
        Type = dataTemplate.Type;
    }
}

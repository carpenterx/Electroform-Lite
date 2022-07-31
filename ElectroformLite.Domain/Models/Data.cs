namespace ElectroformLite.Domain.Models;

public class Data
{
    public int Id { get; set; }

    public string Placeholder { get; set; }

    public string Value { get; set; }

    public int Type { get; set; }

    public Data(string placeholder, string value)
    {
        Placeholder = placeholder;
        Value = value;
    }

    public Data(int id, string placeholder, string value)
    {
        Id = id;
        Placeholder = placeholder;
        Value = value;
    }

    public Data(DataTemplate dataTemplate)
    {
        Placeholder = dataTemplate.Placeholder;
        Value = "";
        Type = dataTemplate.Type;
    }
}

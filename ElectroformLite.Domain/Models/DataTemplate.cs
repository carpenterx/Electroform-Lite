namespace ElectroformLite.Domain.Models;

public class DataTemplate
{
    public int Id { get; set; }

    public string Placeholder { get; set; }

    public int Type { get; set; }

    public DataTemplate(string placeholder, int type)
    {
        Placeholder = placeholder;
        Type = type;
    }
}

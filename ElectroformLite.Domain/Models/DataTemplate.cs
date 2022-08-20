namespace ElectroformLite.Domain.Models;

public class DataTemplate
{
    public Guid Id { get; set; }

    public string Placeholder { get; set; }

    public ICollection<Data> UserData { get; set; }

    public DataTemplate(string placeholder)
    {
        Placeholder = placeholder;
    }
}

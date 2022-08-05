namespace ElectroformLite.Domain.Models;

public class Template
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public Template(string name, string content)
    {
        Name = name;
        Content = content;
    }
}

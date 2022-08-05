namespace ElectroformLite.Domain.Models;

public class Template
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public List<int> DataGroupTemplates { get; set; }

    public Template(string name, string content, List<int> dataGroupTemplates)
    {
        Name = name;
        Content = content;
        DataGroupTemplates = dataGroupTemplates;
    }
}

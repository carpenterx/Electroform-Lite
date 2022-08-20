namespace ElectroformLite.Domain.Models;

public class Template
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    //public List<int> DataGroupTemplates { get; set; }

    public ICollection<Document> Documents { get; set; }

    public Template(string name, string content)
    {
        Name = name;
        Content = content;
    }
}

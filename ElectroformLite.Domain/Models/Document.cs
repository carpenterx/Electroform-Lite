namespace ElectroformLite.Domain.Models;

public class Document
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public Guid TemplateId { get; set; }

    //public ICollection<DataGroup> DataGroups { get; set; }
    public ICollection<Alias> Aliases { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Document(string name, string content)
    {
        Name = name;
        Content = content;
        Aliases = new HashSet<Alias>();
    }
}

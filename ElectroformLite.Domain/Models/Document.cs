using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class Document
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public List<DataGroup> DataGroups { get; set; } = new();

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Document(string name, string content)
    {
        Name = name;
        Content = content;
    }
}

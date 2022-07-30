namespace ElectroformLite.Domain.Models;

public class Document
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public DateTime Created { get; set; }

    public List<int> DataGroups { get; set; } = new();

    public int TemplateId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class Template
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    //public List<int> DataGroupTemplates { get; set; }

    public List<Document> Documents { get; set; } = new();

    public List<DataGroupTemplate> DataGroupTemplates { get; set; } = new();

    public Template(string name, string content)
    {
        Name = name;
        Content = content;
    }
}

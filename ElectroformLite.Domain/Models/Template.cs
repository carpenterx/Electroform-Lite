using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class Template
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    [Required]
    public string Content { get; set; }

    public ICollection<Document> Documents { get; set; }
    public ICollection<DataGroupTemplate> DataGroupTemplates { get; set; }

    public Template(string name, string content)
    {
        Name = name;
        Content = content;
    }
}

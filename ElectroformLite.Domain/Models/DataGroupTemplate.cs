using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataGroupTemplate
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    //public string DataGroupType { get; set; } = string.Empty;

    public List<DataGroup> DataGroups { get; set; } = new();

    public List<DataTemplate> DataTemplates { get; set; } = new();

    public List<Template> Templates { get; set; } = new();

    public DataGroupTemplate(string name)
    {
        Name = name;
    }
}

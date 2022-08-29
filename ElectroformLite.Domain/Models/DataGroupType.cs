using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataGroupType
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Value { get; set; } = string.Empty;

    public List<DataGroupTemplate> DataGroupTemplates { get; set; } = new();

    //public ICollection<DataGroup> DataGroups { get; set; }

    public DataGroupType(string value)
    {
        Value = value;
    }
}

using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataGroupTemplate
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public ICollection<DataGroup> DataGroups { get; set; }

    public DataGroupTemplate(string name, ICollection<DataGroup> dataGroups)
    {
        Name = name;
        DataGroups = dataGroups;
    }
}

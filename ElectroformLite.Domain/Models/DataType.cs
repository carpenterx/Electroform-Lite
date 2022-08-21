using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataType
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Value { get; set; }

    public ICollection<DataTemplate> DataTemplates { get; set; }

    public DataType(string value, ICollection<DataTemplate> dataTemplates)
    {
        Value = value;
        DataTemplates = dataTemplates;
    }
}

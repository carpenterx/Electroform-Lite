using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataType
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Value { get; set; } = string.Empty;

    public List<DataTemplate> DataTemplates { get; set; } = new();

    public DataType()
    {

    }

    public DataType(string value)
    {
        Value = value;
    }
}

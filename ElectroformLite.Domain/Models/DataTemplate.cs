using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataTemplate
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Placeholder { get; set; }

    public Guid DataTypeId { get; set; }

    public DataType DataType { get; set; }
    public ICollection<Data> UserData { get; set; }
    public ICollection<DataGroupTemplate> DataGroupTemplates { get; set; }

    public DataTemplate(string placeholder, Guid dataTypeId)
    {
        Placeholder = placeholder;
        DataTypeId = dataTypeId;
        UserData = new HashSet<Data>();
        DataGroupTemplates = new HashSet<DataGroupTemplate>();
    }
}

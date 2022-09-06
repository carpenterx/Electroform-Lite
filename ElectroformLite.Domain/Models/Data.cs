using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class Data
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Value { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Guid DataTemplateId { get; set; }

    public DataTemplate DataTemplate { get; set; }

    public Data(string value, Guid dataTemplateId)
    {
        Value = value;
        DataTemplateId = dataTemplateId;
    }
}

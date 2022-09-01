using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class Data
{
    public Guid Id { get; set; }

    public string Placeholder { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Value { get; set; } = string.Empty;

    public string DataType { get; set; } = string.Empty;

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Data(string placeholder, string value, string dataType)
    {
        Placeholder = placeholder;
        Value = value;
        DataType = dataType;
    }
}

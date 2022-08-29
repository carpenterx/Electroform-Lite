using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class Data
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Value { get; set; } = string.Empty;

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public Data()
    {

    }

    public Data(string value)
    {
        Value = value;
    }
}

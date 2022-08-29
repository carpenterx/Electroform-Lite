using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataTemplate
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Placeholder { get; set; }

    public List<Data> UserData { get; set; } = new();

    public DataTemplate()
    {

    }
}

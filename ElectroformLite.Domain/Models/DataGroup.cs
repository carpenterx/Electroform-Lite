using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataGroup
{
    public Guid Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public List<Data> UserData { get; set; } = new();

    public List<Document> Documents { get; set; } = new();

    public DataGroup(string name)
    {
        Name = name;
    }
}

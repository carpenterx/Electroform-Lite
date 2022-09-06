using System.ComponentModel.DataAnnotations;

namespace ElectroformLite.Domain.Models;

public class DataGroup
{
    public Guid Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    public string DataGroupPlaceholder { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public ICollection<Data> UserData { get; set; }

    public ICollection<Document> Documents { get; set; }

    public DataGroup(string name, string dataGroupPlaceholder)
    {
        Name = name;
        DataGroupPlaceholder = dataGroupPlaceholder;
    }
}

namespace ElectroformLite.Domain.Models;

public class DataGroup
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    //public DateTime Created { get; set; }

    //public DateTime LastModified { get; set; }

    public ICollection<Data> UserData { get; set; }

    public DataGroup(string name, ICollection<Data> data)
    {
        Name = name;
        UserData = data;
    }
}

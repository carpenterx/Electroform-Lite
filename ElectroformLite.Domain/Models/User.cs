namespace ElectroformLite.Domain.Models;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; }

    public ICollection<DataGroup> DataGroups { get; set; }

    public ICollection<Document> Documents { get; set; }

    public User(string name, string password, bool isAdmin = false)
    {
        Name = name;
        Password = password;
        IsAdmin = isAdmin;
    }
}

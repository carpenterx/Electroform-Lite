namespace ElectroformLite.Domain.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public List<int> DataGroups { get; set; } = new();

    public List<int> Documents { get; set; } = new();

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }
}

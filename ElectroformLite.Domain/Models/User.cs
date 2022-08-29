namespace ElectroformLite.Domain.Models;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool IsAdmin { get; set; } = false;

    public List<Data> UserData { get; set; } = new();

    public List<DataGroup> DataGroups { get; set; } = new();

    public List<Document> Documents { get; set; } = new();

    //public List<DataTemplate> DataTemplates { get; set; } = new();

    //public List<DataGroupTemplate> DataGroupTemplates { get; set; } = new();

    //public List<Template> Templates { get; set; } = new();

    public User(string name, string password, bool isAdmin = false)
    {
        Name = name;
        Password = password;
        IsAdmin = isAdmin;
    }
}

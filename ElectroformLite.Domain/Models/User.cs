﻿namespace ElectroformLite.Domain.Models;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; } = false;

    public ICollection<Data> UserData { get; set; }
    public ICollection<DataGroup> DataGroups { get; set; }
    public ICollection<Document> Documents { get; set; }
    //public ICollection<DataTemplate> DataTemplates { get; set; }
    //public ICollection<DataGroupTemplate> DataGroupTemplates { get; set; }
    //public ICollection<Template> Templates { get; set; }

    public User(string name, string password, bool isAdmin = false)
    {
        Name = name;
        Password = password;
        IsAdmin = isAdmin;
        UserData = new HashSet<Data>();
        DataGroups = new HashSet<DataGroup>();
        Documents = new HashSet<Document>();
    }
}

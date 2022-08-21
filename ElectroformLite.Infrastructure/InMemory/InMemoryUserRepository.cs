using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryUserRepository : IUserRepository
{
    readonly List<User> users = new();

    public void Create(User user)
    {
        user.Id = Guid.NewGuid();
        users.Add(user);
    }

    public void Delete(Guid id)
    {
        User user = users.FirstOrDefault(u => u.Id == id);
        users.Remove(user);
    }

    public User GetUser(Guid id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }

    public User GetUserByName(string name)
    {
        return users.FirstOrDefault(u => u.Name == name);
    }

    public List<User> GetUsers()
    {
        return users;
    }

    public void Update(User user)
    {
        User? userToEdit = users.FirstOrDefault(d => d.Id == user.Id);
        if (userToEdit is not null)
        {
            userToEdit.Name = user.Name;
            userToEdit.Password = user.Password;
            userToEdit.DataGroups = user.DataGroups;
            userToEdit.Documents = user.Documents;
        }
    }
}

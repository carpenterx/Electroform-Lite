using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.Database;

public class UserRepository : IUserRepository
{
    public void Create(User user)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public User GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public User GetUserByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}

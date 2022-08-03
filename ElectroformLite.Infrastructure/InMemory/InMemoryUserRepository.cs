using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryUserRepository : IUserRepository
{
    public User GetUser(string name)
    {
        return new User()
        {
            Name = name,
        };
    }
}

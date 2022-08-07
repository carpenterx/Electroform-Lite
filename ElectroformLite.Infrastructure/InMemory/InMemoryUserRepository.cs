using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Infrastructure.InMemory;

public class InMemoryUserRepository : IUserRepository
{
    public User GetUser(int id)
    {
        return new User()
        {
            Id = id,
            Name = "New User"
        };
    }
}

using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IUserRepository
{
    User GetUser(string name);
}

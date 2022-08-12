using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IUserRepository
{
    void Create(User user);
    void Delete(int id);
    void Update(User user);
    User GetUser(int id);
    List<User> GetUsers();
}

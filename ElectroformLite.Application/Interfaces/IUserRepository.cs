using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Interfaces;

public interface IUserRepository
{
    void Create(User user);
    void Delete(Guid id);
    void Update(User user);
    User GetUser(Guid id);
    User GetUserByName(string name);
    List<User> GetUsers();
}

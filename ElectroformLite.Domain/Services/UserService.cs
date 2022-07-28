using ElectroformLite.Domain.Models;

namespace ElectroformLite.Domain.Services;

public class UserService
{
    public static User GetUser(string name, List<int> dataGroups, List<int> documents)
    {
        return new User()
        {
            Name = name,
            DataGroups = dataGroups,
            Documents = documents
        };
    }
}

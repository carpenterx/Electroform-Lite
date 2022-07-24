using System.Collections;

namespace Electroform_Lite.Models;

internal class Users : IEnumerable
{
    private readonly User[] _users;

    public Users(User[] users)
    {
        _users = new User[users.Length];

        for (int i = 0; i < users.Length; i++)
        {
            _users[i] = users[i];
        }
    }

    public UsersEnumerator GetEnumerator()
    {
        return new UsersEnumerator(_users);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}

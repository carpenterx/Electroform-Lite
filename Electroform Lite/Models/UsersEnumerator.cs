using System.Collections;

namespace Electroform_Lite.Models;

internal class UsersEnumerator : IEnumerator
{
    private readonly User[] _users;
    int position = -1;

    public UsersEnumerator(User[] users)
    {
        _users = users;
    }

    public User Current
    {
        get
        {
            try
            {
                return _users[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public bool MoveNext()
    {
        position++;
        return position < _users.Length;
    }

    public void Reset()
    {
        position = -1;
    }
}

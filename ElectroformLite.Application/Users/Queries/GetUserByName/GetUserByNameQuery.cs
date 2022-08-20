using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Users.Queries.GetUserByName;

public class GetUserByNameQuery : IRequest<User>
{
    public string UserName { get; set; }

    public GetUserByNameQuery(string userName)
    {
        UserName = userName;
    }
}

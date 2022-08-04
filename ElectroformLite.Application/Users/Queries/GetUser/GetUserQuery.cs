using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Users.Queries.GetUser;

public class GetUserQuery : IRequest<User>
{
    public int UserId { get; set; }

    public GetUserQuery(int userId)
    {
        UserId = userId;
    }
}

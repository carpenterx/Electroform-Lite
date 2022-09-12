using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Users.Queries.GetUser;

public class GetUserQuery : IRequest<User>
{
    public Guid UserId { get; set; }

    public GetUserQuery(Guid userId)
    {
        UserId = userId;
    }
}

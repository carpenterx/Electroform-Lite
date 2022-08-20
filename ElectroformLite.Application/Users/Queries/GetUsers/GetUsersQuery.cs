using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<User>>
{

}

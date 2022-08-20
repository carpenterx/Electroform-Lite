using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    private readonly IUserRepository _repository;

    public GetUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetUsers();

        return Task.FromResult(result);
    }
}

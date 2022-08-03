using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly IUserRepository _repository;

    public GetUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetUser("Sorin");

        return Task.FromResult(result);
    }
}

using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Users.Queries.GetUserByName;

public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, User>
{
    private readonly IUserRepository _repository;

    public GetUserByNameQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<User> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetUserByName(request.UserName);

        return Task.FromResult(result);
    }
}

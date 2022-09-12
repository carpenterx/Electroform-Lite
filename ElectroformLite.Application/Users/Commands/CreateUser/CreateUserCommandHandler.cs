using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = request.User;
        _repository.Create(user);

        return Task.FromResult(user.Id);
    }
}
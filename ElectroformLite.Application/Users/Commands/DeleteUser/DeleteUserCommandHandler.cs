using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.UserId);

        return Task.FromResult(Unit.Value);
    }
}
using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.Users.Commands.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    private readonly IUserRepository _repository;

    public EditUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.User);

        return Task.FromResult(Unit.Value);
    }
}
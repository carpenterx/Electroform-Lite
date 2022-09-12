using MediatR;

namespace ElectroformLite.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid UserId { get; set; }

    public DeleteUserCommand(Guid userId)
    {
        UserId = userId;
    }
}

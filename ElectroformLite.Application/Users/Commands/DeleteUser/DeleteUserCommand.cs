using MediatR;

namespace ElectroformLite.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public int UserId { get; set; }

    public DeleteUserCommand(int userId)
    {
        UserId = userId;
    }
}

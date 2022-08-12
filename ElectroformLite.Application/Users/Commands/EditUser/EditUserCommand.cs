using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Users.Commands.EditUser;

public class EditUserCommand : IRequest
{
    public User User { get; set; }

    public EditUserCommand(User user)
    {
        User = user;
    }
}

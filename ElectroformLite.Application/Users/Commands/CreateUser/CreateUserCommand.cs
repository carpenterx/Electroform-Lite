using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public User User { get; set; }

    public CreateUserCommand(User user)
    {
        User = user;
    }
}

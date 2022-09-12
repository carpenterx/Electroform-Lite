using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.DeleteData;

public class DeleteDataCommand : IRequest<Data?>
{
    public Guid DataId { get; set; }

    public DeleteDataCommand(Guid dataId)
    {
        DataId = dataId;
    }
}

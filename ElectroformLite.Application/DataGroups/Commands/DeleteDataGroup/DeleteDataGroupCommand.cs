using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;

public class DeleteDataGroupCommand : IRequest
{
    public int DataGroupId { get; set; }

    public DeleteDataGroupCommand(int dataGroupId)
    {
        DataGroupId = dataGroupId;
    }
}

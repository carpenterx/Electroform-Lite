using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.DeleteDataFromDataGroup;

public class DeleteDataFromDataGroupCommand : IRequest<DataGroup?>
{
    public Guid DataGroupId { get; set; }
    public Guid DataId { get; set; }

    public DeleteDataFromDataGroupCommand(Guid dataGroupId, Guid dataId)
    {
        DataGroupId = dataGroupId;
        DataId = dataId;
    }
}

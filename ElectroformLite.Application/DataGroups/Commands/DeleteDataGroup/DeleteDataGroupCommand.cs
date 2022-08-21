using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;

public class DeleteDataGroupCommand : IRequest
{
    public Guid DataGroupId { get; set; }

    public DeleteDataGroupCommand(Guid dataGroupId)
    {
        DataGroupId = dataGroupId;
    }
}

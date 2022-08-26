using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.AddDataToDataGroup;

public class AddDataToDataGroupCommand : IRequest<DataGroup?>
{
    public Guid DataGroupId { get; set; }
    public Guid DataId { get; set; }

    public AddDataToDataGroupCommand(Guid dataGroupId, Guid dataId)
    {
        DataGroupId = dataGroupId;
        DataId = dataId;
    }
}

using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.DeleteDataGroupType;

public class DeleteDataGroupTypeCommand : IRequest
{
    public int DataGroupTypeId { get; set; }

    public DeleteDataGroupTypeCommand(int dataGroupTypeId)
    {
        DataGroupTypeId = dataGroupTypeId;
    }
}

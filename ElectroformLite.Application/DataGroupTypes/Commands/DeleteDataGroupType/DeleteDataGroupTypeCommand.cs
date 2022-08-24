using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.DeleteDataGroupType;

public class DeleteDataGroupTypeCommand : IRequest<DataGroupType>
{
    public Guid DataGroupTypeId { get; set; }

    public DeleteDataGroupTypeCommand(Guid dataGroupTypeId)
    {
        DataGroupTypeId = dataGroupTypeId;
    }
}

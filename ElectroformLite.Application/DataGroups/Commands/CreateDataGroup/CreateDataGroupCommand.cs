using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommand : IRequest<Guid>
{
    public DataGroup DataGroup { get; set; }

    public CreateDataGroupCommand(DataGroup dataGroup)
    {
        DataGroup = dataGroup;
    }
}

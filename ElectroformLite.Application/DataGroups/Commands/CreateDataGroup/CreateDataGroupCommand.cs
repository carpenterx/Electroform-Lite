using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommand : IRequest<int>
{
    public DataGroup DataGroup { get; set; }

    public CreateDataGroupCommand(DataGroup dataGroup)
    {
        DataGroup = dataGroup;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.EditDataGroup;

public class EditDataGroupCommand : IRequest<int>
{
    public DataGroup DataGroup { get; set; }

    public EditDataGroupCommand(DataGroup dataGroup)
    {
        DataGroup = dataGroup;
    }
}

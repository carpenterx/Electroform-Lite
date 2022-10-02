using ElectroformLite.Application.Dto;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.EditDataGroup;

public class EditDataGroupCommand : IRequest
{
    public DataGroupPutDto DataGroupPutDto { get; set; }

    public EditDataGroupCommand(DataGroupPutDto dataGroupPutDto)
    {
        DataGroupPutDto = dataGroupPutDto;
    }
}

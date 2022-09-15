using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.EditDataGroupType;

public class EditDataGroupTypeCommand : IRequest
{
    public Guid DataGroupTypeId { get; set; }
    public string DataGroupTypeValue { get; set; }

    public EditDataGroupTypeCommand(Guid dataGroupTypeId, string dataGroupTypeValue)
    {
        DataGroupTypeId = dataGroupTypeId;
        DataGroupTypeValue = dataGroupTypeValue;
    }
}

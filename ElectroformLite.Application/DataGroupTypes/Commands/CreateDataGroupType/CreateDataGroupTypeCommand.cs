using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;

public class CreateDataGroupTypeCommand : IRequest<Guid>
{
    public string TypeValue { get; set; }

    public CreateDataGroupTypeCommand(string typeValue)
    {
        TypeValue = typeValue;
    }
}

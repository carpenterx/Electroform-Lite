using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;

public class CreateDataGroupTypeCommand : IRequest<int>
{
    public string TypeValue { get; set; }

    public CreateDataGroupTypeCommand(string typeValue)
    {
        TypeValue = typeValue;
    }
}

using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.CreateDataType;

public class CreateDataTypeCommand : IRequest<int>
{
    public string TypeValue { get; set; }

    public CreateDataTypeCommand(string typeValue)
    {
        TypeValue = typeValue;
    }
}

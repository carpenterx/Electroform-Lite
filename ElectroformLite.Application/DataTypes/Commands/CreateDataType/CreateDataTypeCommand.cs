using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.CreateDataType;

public class CreateDataTypeCommand : IRequest<DataType>
{
    public string TypeValue { get; set; }

    public CreateDataTypeCommand(string typeValue)
    {
        TypeValue = typeValue;
    }
}

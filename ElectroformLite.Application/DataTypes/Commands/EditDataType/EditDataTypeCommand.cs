using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.EditDataType;

public class EditDataTypeCommand : IRequest
{
    public Guid DataTypeId { get; set; }
    public string NewDataTypeValue { get; set; }

    public EditDataTypeCommand(Guid dataTypeId, string newDataTypeValue)
    {
        DataTypeId = dataTypeId;
        NewDataTypeValue = newDataTypeValue;
    }
}

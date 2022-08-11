using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.DeleteDataType;

public class DeleteDataTypeCommand : IRequest
{
    public int DataTypeId { get; set; }

    public DeleteDataTypeCommand(int dataTypeId)
    {
        DataTypeId = dataTypeId;
    }
}

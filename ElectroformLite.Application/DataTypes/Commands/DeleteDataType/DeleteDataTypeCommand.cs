using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.DeleteDataType;

public class DeleteDataTypeCommand : IRequest
{
    public Guid DataTypeId { get; set; }

    public DeleteDataTypeCommand(Guid dataTypeId)
    {
        DataTypeId = dataTypeId;
    }
}

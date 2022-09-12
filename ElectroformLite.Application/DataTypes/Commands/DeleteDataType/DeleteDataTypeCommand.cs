using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.DeleteDataType;

public class DeleteDataTypeCommand : IRequest<DataType?>
{
    public Guid DataTypeId { get; set; }

    public DeleteDataTypeCommand(Guid dataTypeId)
    {
        DataTypeId = dataTypeId;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.EditDataType;

public class EditDataTypeCommand : IRequest
{
    public DataType DataType { get; set; }

    public EditDataTypeCommand(DataType dataType)
    {
        DataType = dataType;
    }
}

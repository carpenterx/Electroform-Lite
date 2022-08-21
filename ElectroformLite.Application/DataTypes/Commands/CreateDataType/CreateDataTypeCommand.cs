using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.CreateDataType;

public class CreateDataTypeCommand : IRequest<Guid>
{
    public string TypeValue { get; set; }

    public ICollection<DataTemplate> DataTemplates { get; set; }

    public CreateDataTypeCommand(string typeValue, ICollection<DataTemplate> dataTemplates)
    {
        TypeValue = typeValue;
        DataTemplates = dataTemplates;
    }
}

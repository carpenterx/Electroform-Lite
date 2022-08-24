using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.CreateDataGroupType;

public class CreateDataGroupTypeCommand : IRequest<DataGroupType>
{
    public string TypeValue { get; set; }

    public CreateDataGroupTypeCommand(string typeValue)
    {
        TypeValue = typeValue;
    }
}

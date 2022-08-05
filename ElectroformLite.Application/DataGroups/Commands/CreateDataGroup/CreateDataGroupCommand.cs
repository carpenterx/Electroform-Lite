using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommand : IRequest<int>
{
    /*public DataTemplate DataTemplate { get; set; }

    public string DataValue { get; set; }

    public CreateDataCommand(DataTemplate dataTemplate, string dataValue)
    {
        DataTemplate = dataTemplate;
        DataValue = dataValue;
    }*/

    public DataGroup DataGroup { get; set; }

    public CreateDataGroupCommand(DataGroup dataGroup)
    {
        DataGroup = dataGroup;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.CreateData;

public class CreateDataCommand : IRequest<int>
{
    /*public DataTemplate DataTemplate { get; set; }

    public string DataValue { get; set; }

    public CreateDataCommand(DataTemplate dataTemplate, string dataValue)
    {
        DataTemplate = dataTemplate;
        DataValue = dataValue;
    }*/

    public Data Data { get; set; }

    public CreateDataCommand(Data data)
    {
        Data = data;
    }
}

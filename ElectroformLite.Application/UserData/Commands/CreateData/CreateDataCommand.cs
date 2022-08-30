using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Commands.CreateData;

public class CreateDataCommand : IRequest<Data?>
{
    public Guid DataTemplateId { get; set; }
    public string Value { get; set; }

    public CreateDataCommand(Guid dataTemplateId, string value)
    {
        DataTemplateId = dataTemplateId;
        Value = value;
    }
}

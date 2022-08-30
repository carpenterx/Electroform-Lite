using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommand : IRequest<DataGroup?>
{
    public Guid DataGroupTemplateId { get; set; }
    public string Name { get; set; }

    public CreateDataGroupCommand(Guid dataGroupTemplateId, string name)
    {
        DataGroupTemplateId = dataGroupTemplateId;
        Name = name;
    }
}

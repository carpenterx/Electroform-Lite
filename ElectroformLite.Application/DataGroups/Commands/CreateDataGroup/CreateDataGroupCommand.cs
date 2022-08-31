using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.CreateDataGroup;

public class CreateDataGroupCommand : IRequest<DataGroup?>
{
    public Guid DataGroupTemplateId { get; set; }
    public string Name { get; set; }
    public List<KeyValuePair<Guid, string>> DataProperties { get; set; }

    public CreateDataGroupCommand(Guid dataGroupTemplateId, string name, List<KeyValuePair<Guid, string>> dataProperties)
    {
        DataGroupTemplateId = dataGroupTemplateId;
        Name = name;
        DataProperties = dataProperties;
    }
}

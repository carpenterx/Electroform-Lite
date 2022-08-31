using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommand : IRequest<DataGroupTemplate?>
{
    public Guid DataGroupTypeId { get; set; }
    public string Name { get; set; }
    public List<Guid> DataTemplateIds { get; set; }

    public CreateDataGroupTemplateCommand(Guid dataGroupTypeId, string name, List<Guid> dataTemplateIds)
    {
        DataGroupTypeId = dataGroupTypeId;
        Name = name;
        DataTemplateIds = dataTemplateIds;
    }
}

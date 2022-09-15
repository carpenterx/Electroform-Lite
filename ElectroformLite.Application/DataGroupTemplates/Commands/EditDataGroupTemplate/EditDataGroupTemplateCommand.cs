using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.EditDataGroupTemplate;

public class EditDataGroupTemplateCommand : IRequest<DataGroupTemplate?>
{
    public Guid DataGroupTemplateId { get; set; }

    public List<Guid> DataTemplateIds { get; set; }

    public EditDataGroupTemplateCommand(Guid dataGroupTemplateId, List<Guid> dataTemplateIds)
    {
        DataGroupTemplateId = dataGroupTemplateId;
        DataTemplateIds = dataTemplateIds;
    }
}

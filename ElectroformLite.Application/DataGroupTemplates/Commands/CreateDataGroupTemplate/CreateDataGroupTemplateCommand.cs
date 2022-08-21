using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommand : IRequest<Guid>
{
    public string TemplateName { get; set; }

    public ICollection<DataGroup> DataGroups { get; set; }

    public CreateDataGroupTemplateCommand(string templateName, ICollection<DataGroup> dataGroups)
    {
        TemplateName = templateName;
        DataGroups = dataGroups;
    }
}

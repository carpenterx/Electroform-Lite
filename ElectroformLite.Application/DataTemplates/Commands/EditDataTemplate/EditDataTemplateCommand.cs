using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;

public class EditDataTemplateCommand : IRequest
{
    public Guid DataTemplateId { get; set; }

    public string DataTemplatePlaceholder { get; set; }

    public EditDataTemplateCommand(Guid dataTemplateId, string dataTemplatePlaceholder)
    {
        DataTemplateId = dataTemplateId;
        DataTemplatePlaceholder = dataTemplatePlaceholder;
    }
}

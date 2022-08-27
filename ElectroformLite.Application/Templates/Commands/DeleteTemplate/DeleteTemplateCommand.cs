using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommand : IRequest<Template?>
{
    public Guid TemplateId { get; set; }

    public DeleteTemplateCommand(Guid templateId)
    {
        TemplateId = templateId;
    }
}

using MediatR;

namespace ElectroformLite.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommand : IRequest
{
    public int TemplateId { get; set; }

    public DeleteTemplateCommand(int templateId)
    {
        TemplateId = templateId;
    }
}

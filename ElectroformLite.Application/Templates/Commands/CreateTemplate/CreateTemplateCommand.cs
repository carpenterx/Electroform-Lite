using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommand : IRequest<Guid>
{
    public string TemplateName { get; set; }

    public string TemplateContent { get; set; }

    public CreateTemplateCommand(string templateName, string templateContent)
    {
        TemplateName = templateName;
        TemplateContent = templateContent;
    }
}

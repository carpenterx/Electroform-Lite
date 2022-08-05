using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplateCommand;

public class CreateTemplateCommand : IRequest<int>
{
    public string TemplateName { get; set; }

    public string TemplateContent { get; set; }

    public CreateTemplateCommand(string templateName, string templateContent)
    {
        TemplateName = templateName;
        TemplateContent = templateContent;
    }
}

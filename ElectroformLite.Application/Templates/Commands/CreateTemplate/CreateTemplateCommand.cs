using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommand : IRequest<Template>
{
    public Template Template { get; set; }

    public CreateTemplateCommand(Template template)
    {
        Template = template;
    }
}

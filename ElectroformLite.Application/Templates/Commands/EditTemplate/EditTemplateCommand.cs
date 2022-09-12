using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.EditTemplate;

public class EditTemplateCommand : IRequest<Template?>
{
    public Template Template { get; set; }

    public EditTemplateCommand(Template template)
    {
        Template = template;
    }
}

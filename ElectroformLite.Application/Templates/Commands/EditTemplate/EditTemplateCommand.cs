using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.EditTemplate;

public class EditTemplateCommand : IRequest
{
    public Template Template { get; set; }

    public EditTemplateCommand(Template template)
    {
        Template = template;
    }
}

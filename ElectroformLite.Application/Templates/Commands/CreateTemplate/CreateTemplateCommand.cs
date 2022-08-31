using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommand : IRequest<Template?>
{
    public string Name { get; set; }
    public string Content { get; set; }
    public List<Guid> DataGroupTemplateIds { get; set; }

    public CreateTemplateCommand(string name, string content, List<Guid> dataGroupTemplateIds)
    {
        Name = name;
        Content = content;
        DataGroupTemplateIds = dataGroupTemplateIds;
    }
}

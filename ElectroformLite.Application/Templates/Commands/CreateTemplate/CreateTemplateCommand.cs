using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplate;

public class CreateTemplateCommand : IRequest<Template?>
{
    public string Name { get; set; }
    public string Content { get; set; }
    //public List<Guid> DataGroupTemplateIds { get; set; }
    public Dictionary<Guid, string> AliasTemplateData { get; set; }

    public CreateTemplateCommand(string name, string content, Dictionary<Guid, string> aliasTemplateData)
    {
        Name = name;
        Content = content;
        AliasTemplateData = aliasTemplateData;
    }
}

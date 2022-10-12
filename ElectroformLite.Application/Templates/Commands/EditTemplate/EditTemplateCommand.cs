using ElectroformLite.Application.Dto;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.EditTemplate;

public class EditTemplateCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    //public Dictionary<Guid, string> AliasTemplateData { get; set; }
    public List<AliasTemplateData> AliasTemplatesData { get; set; }
    public EditTemplateCommand(Guid id, string name, string content, List<AliasTemplateData> aliasTemplatesData)
    {
        Id = id;
        Name = name;
        Content = content;
        AliasTemplatesData = aliasTemplatesData;
    }
}

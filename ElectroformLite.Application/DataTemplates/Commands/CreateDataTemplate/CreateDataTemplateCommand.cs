using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommand : IRequest<int>
{
    public string TemplatePlaceholder { get; set; }

    public int TemplateType { get; set; }

    public CreateDataTemplateCommand(string templatePlaceholder, int templateType)
    {
        TemplatePlaceholder = templatePlaceholder;
        TemplateType = templateType;
    }
}

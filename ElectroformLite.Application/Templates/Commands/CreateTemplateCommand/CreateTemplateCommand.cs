using MediatR;

namespace ElectroformLite.Application.Templates.Commands.CreateTemplateCommand;

public class CreateTemplateCommand : IRequest<int>
{
    public string TemplateName { get; set; }

    public string TemplateContent { get; set; }

    public List<int> DataGroupTemplates { get; set; }

    public CreateTemplateCommand(string templateName, string templateContent, List<int> dataGroupTemplates)
    {
        TemplateName = templateName;
        TemplateContent = templateContent;
        DataGroupTemplates = dataGroupTemplates;
    }
}

using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.CreateDataGroupTemplate;

public class CreateDataGroupTemplateCommand : IRequest<int>
{
    public string TemplateName { get; set; }

    public int TemplateType { get; set; }

    public List<int> DataTemplates { get; set; }

    public CreateDataGroupTemplateCommand(string templateName, int templateType, List<int> dataTemplates)
    {
        TemplateName = templateName;
        TemplateType = templateType;
        DataTemplates = dataTemplates;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.EditDataTemplate;

public class EditDataTemplateCommand : IRequest
{
    public DataTemplate DataTemplate { get; set; }

    public EditDataTemplateCommand(DataTemplate dataTemplate)
    {
        DataTemplate = dataTemplate;
    }
}

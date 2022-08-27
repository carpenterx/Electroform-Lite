using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommand : IRequest<DataTemplate>
{
    public DataTemplate DataTemplate { get; set; }

    public CreateDataTemplateCommand(DataTemplate dataTemplate)
    {
        DataTemplate = dataTemplate;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommand : IRequest<DataTemplate>
{
    public Guid DataTypeId { get; set; }
    public string Placeholder { get; set; }

    public CreateDataTemplateCommand(Guid dataTypeId, string placeholder)
    {
        DataTypeId = dataTypeId;
        Placeholder = placeholder;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.CreateDataTemplate;

public class CreateDataTemplateCommand : IRequest<Guid>
{
    public string TemplatePlaceholder { get; set; }

    public ICollection<Data> UserData { get; set; }

    public CreateDataTemplateCommand(string templatePlaceholder, ICollection<Data> userData)
    {
        TemplatePlaceholder = templatePlaceholder;
        UserData = userData;
    }
}

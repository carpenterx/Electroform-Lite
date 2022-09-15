using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;

public class DeleteDataTemplateCommand : IRequest
{
    public Guid DataTemplateId { get; set; }

    public DeleteDataTemplateCommand(Guid dataTemplateId)
    {
        DataTemplateId = dataTemplateId;
    }
}

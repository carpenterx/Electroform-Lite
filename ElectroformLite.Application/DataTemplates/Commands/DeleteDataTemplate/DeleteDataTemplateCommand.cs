using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;

public class DeleteDataTemplateCommand : IRequest
{
    public int DataTemplateId { get; set; }

    public DeleteDataTemplateCommand(int dataTemplateId)
    {
        DataTemplateId = dataTemplateId;
    }
}

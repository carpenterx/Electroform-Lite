using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;

public class DeleteDataGroupTemplateCommand : IRequest
{
    public int DataGroupTemplateId { get; set; }

    public DeleteDataGroupTemplateCommand(int dataGroupTemplateId)
    {
        DataGroupTemplateId = dataGroupTemplateId;
    }
}

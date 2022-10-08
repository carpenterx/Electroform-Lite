using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;

public class DeleteDataGroupTemplateCommand : IRequest
{
    public Guid DataGroupTemplateId { get; set; }

    public DeleteDataGroupTemplateCommand(Guid dataGroupTemplateId)
    {
        DataGroupTemplateId = dataGroupTemplateId;
    }
}

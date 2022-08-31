using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<Document?>
{
    public Guid TemplateId { get; set; }
    public List<Guid> DataGroupIds { get; set; }

    public CreateDocumentCommand(Guid templateId, List<Guid> dataGroupIds)
    {
        TemplateId = templateId;
        DataGroupIds = dataGroupIds;
    }
}

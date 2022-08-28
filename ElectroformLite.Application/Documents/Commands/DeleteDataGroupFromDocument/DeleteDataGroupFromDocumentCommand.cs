using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDataGroupFromDocument;

public class DeleteDataGroupFromDocumentCommand : IRequest<Document?>
{
    public Guid DocumentId { get; set; }
    public Guid DataGroupId { get; set; }

    public DeleteDataGroupFromDocumentCommand(Guid documentId, Guid dataGroupId)
    {
        DocumentId = documentId;
        DataGroupId = dataGroupId;
    }
}

using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommand : IRequest<Document?>
{
    public Guid DocumentId { get; set; }

    public DeleteDocumentCommand(Guid documentId)
    {
        DocumentId = documentId;
    }
}

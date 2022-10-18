using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommand : IRequest
{
    public Guid DocumentId { get; set; }

    public DeleteDocumentCommand(Guid documentId)
    {
        DocumentId = documentId;
    }
}

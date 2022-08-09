using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommand : IRequest
{
    public int DocumentId { get; set; }

    public DeleteDocumentCommand(int documentId)
    {
        DocumentId = documentId;
    }
}

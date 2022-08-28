using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Documents.Queries.GetDocument;

public class GetDocumentQuery : IRequest<Document?>
{
    public Guid DocumentId { get; set; }

    public GetDocumentQuery(Guid documentId)
    {
        DocumentId = documentId;
    }
}

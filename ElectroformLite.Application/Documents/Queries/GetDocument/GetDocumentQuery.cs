using MediatR;
using ElectroformLite.Domain.Models;

namespace ElectroformLite.Application.Documents.Queries.GetDocument;

public class GetDocumentQuery : IRequest<Document>
{
    public int DocumentId { get; set; }

    public GetDocumentQuery(int documentId)
    {
        DocumentId = documentId;
    }
}

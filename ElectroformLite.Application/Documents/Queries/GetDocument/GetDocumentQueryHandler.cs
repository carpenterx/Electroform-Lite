using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Queries.GetDocument;

public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Document>
{
    private readonly IDocumentRepository _repository;

    public GetDocumentQueryHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public Task<Document> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDocument(request.DocumentId);

        return Task.FromResult(result);
    }
}
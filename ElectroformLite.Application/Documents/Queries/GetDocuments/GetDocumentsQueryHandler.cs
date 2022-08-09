using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Queries.GetDocuments;

public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, List<Document>>
{
    private readonly IDocumentRepository _repository;

    public GetDocumentsQueryHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Document>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDocuments();

        return Task.FromResult(result);
    }
}
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, int>
{
    private readonly IDocumentRepository _repository;

    public CreateDocumentCommandHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        Document document = request.Document;
        _repository.Create(document);

        return Task.FromResult(document.Id);
    }
}
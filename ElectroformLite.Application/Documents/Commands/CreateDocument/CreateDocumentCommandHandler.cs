using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.CreateDocument;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Guid>
{
    private readonly IDocumentRepository _repository;

    public CreateDocumentCommandHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        Document document = request.Document;
        _repository.Create(document);

        return Task.FromResult(document.Id);
    }
}
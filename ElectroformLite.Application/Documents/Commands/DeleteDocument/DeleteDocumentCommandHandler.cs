using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
{
    private readonly IDocumentRepository _repository;

    public DeleteDocumentCommandHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DocumentId);

        return Task.FromResult(Unit.Value);
    }
}
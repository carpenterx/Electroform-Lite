using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.Documents.Commands.EditDocument;

public class EditDocumentCommandHandler : IRequestHandler<EditDocumentCommand>
{
    private readonly IDocumentRepository _repository;

    public EditDocumentCommandHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.Document);

        return Task.FromResult(Unit.Value);
    }
}
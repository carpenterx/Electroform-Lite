using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand>
{
    private readonly ITemplateRepository _repository;

    public DeleteTemplateCommandHandler(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.TemplateId);

        return Task.FromResult(Unit.Value);
    }
}
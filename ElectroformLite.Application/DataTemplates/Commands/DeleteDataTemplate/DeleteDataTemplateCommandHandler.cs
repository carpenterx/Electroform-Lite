using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataTemplates.Commands.DeleteDataTemplate;

public class DeleteDataTemplateCommandHandler : IRequestHandler<DeleteDataTemplateCommand>
{
    private readonly IDataTemplateRepository _repository;

    public DeleteDataTemplateCommandHandler(IDataTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDataTemplateCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DataTemplateId);

        return Task.FromResult(Unit.Value);
    }
}
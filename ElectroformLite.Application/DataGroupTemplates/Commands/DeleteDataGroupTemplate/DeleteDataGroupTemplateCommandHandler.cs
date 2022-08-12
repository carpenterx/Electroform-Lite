using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataGroupTemplates.Commands.DeleteDataGroupTemplate;

public class DeleteDataGroupTemplateCommandHandler : IRequestHandler<DeleteDataGroupTemplateCommand>
{
    private readonly IDataGroupTemplateRepository _repository;

    public DeleteDataGroupTemplateCommandHandler(IDataGroupTemplateRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDataGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DataGroupTemplateId);

        return Task.FromResult(Unit.Value);
    }
}
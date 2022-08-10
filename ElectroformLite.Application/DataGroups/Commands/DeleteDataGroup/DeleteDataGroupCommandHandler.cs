using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Commands.DeleteDataGroup;

public class DeleteDataGroupCommandHandler : IRequestHandler<DeleteDataGroupCommand>
{
    private readonly IDataGroupRepository _repository;

    public DeleteDataGroupCommandHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDataGroupCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DataGroupId);

        return Task.FromResult(Unit.Value);
    }
}
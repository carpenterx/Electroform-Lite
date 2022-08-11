using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Commands.DeleteDataGroupType;

public class DeleteDataGroupTypeCommandHandler : IRequestHandler<DeleteDataGroupTypeCommand>
{
    private readonly IDataGroupTypeRepository _repository;

    public DeleteDataGroupTypeCommandHandler(IDataGroupTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDataGroupTypeCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DataGroupTypeId);

        return Task.FromResult(Unit.Value);
    }
}
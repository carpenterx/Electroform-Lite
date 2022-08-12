using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.DeleteDataType;

public class DeleteDataTypeCommandHandler : IRequestHandler<DeleteDataTypeCommand>
{
    private readonly IDataTypeRepository _repository;

    public DeleteDataTypeCommandHandler(IDataTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(DeleteDataTypeCommand request, CancellationToken cancellationToken)
    {
        _repository.Delete(request.DataTypeId);

        return Task.FromResult(Unit.Value);
    }
}
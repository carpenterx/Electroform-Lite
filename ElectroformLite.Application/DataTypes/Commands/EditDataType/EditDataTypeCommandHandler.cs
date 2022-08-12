using ElectroformLite.Application.Interfaces;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.EditDataType;

public class EditDataTypeCommandHandler : IRequestHandler<EditDataTypeCommand>
{
    private readonly IDataTypeRepository _repository;

    public EditDataTypeCommandHandler(IDataTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<Unit> Handle(EditDataTypeCommand request, CancellationToken cancellationToken)
    {
        _repository.Update(request.DataType);

        return Task.FromResult(Unit.Value);
    }
}
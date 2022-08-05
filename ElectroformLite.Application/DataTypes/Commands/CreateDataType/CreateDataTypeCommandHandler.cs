using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.CreateDataType;

public class CreateDataTypeCommandHandler : IRequestHandler<CreateDataTypeCommand, int>
{
    private readonly IDataTypeRepository _repository;

    public CreateDataTypeCommandHandler(IDataTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<int> Handle(CreateDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType dataType = new(request.TypeValue);
        _repository.Create(dataType);

        return Task.FromResult(dataType.Id);
    }
}
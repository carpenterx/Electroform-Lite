using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Commands.CreateDataType;

public class CreateDataTypeCommandHandler : IRequestHandler<CreateDataTypeCommand, Guid>
{
    private readonly IDataTypeRepository _repository;

    public CreateDataTypeCommandHandler(IDataTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateDataTypeCommand request, CancellationToken cancellationToken)
    {
        DataType dataType = new(request.TypeValue, request.DataTemplates);
        _repository.Create(dataType);

        return Task.FromResult(dataType.Id);
    }
}
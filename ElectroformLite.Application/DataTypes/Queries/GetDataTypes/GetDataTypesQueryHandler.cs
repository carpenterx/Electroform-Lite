using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataTypes;

public class GetDataTypesQueryHandler : IRequestHandler<GetDataTypesQuery, List<DataType>>
{
    private readonly IDataTypeRepository _repository;

    public GetDataTypesQueryHandler(IDataTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataType>> Handle(GetDataTypesQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataTypes();

        return Task.FromResult(result);
    }
}

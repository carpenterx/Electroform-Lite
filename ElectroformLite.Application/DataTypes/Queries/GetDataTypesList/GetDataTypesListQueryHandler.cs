using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataTypes.Queries.GetDataTypesList;

public class GetDataTypesListQueryHandler : IRequestHandler<GetDataTypesListQuery, List<DataType>>
{
    private readonly IDataTypeRepository _repository;

    public GetDataTypesListQueryHandler(IDataTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataType>> Handle(GetDataTypesListQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataTypes();

        return Task.FromResult(result);
    }
}

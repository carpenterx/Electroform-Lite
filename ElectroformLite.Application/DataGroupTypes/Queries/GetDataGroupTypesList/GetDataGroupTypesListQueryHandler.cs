using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypesList;

public class GetDataGroupTypesListQueryHandler : IRequestHandler<GetDataGroupTypesListQuery, List<DataGroupType>>
{
    private readonly IDataGroupTypeRepository _repository;

    public GetDataGroupTypesListQueryHandler(IDataGroupTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataGroupType>> Handle(GetDataGroupTypesListQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroupTypes();

        return Task.FromResult(result);
    }
}

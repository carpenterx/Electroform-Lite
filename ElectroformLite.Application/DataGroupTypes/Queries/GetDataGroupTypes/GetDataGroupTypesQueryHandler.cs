using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupTypes;

public class GetDataGroupTypesQueryHandler : IRequestHandler<GetDataGroupTypesQuery, List<DataGroupType>>
{
    private readonly IDataGroupTypeRepository _repository;

    public GetDataGroupTypesQueryHandler(IDataGroupTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DataGroupType>> Handle(GetDataGroupTypesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetDataGroupTypes();

        return result;
    }
}

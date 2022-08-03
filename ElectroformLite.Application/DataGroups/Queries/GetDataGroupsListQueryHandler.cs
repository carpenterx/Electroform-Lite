using ElectroformLite.Application.DataTypes.Queries.GetDataTypesList;
using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries;

public class GetDataGroupsListQueryHandler : IRequestHandler<GetDataGroupsListQuery, List<DataGroup>>
{
    private readonly IDataGroupRepository _repository;

    public GetDataGroupsListQueryHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataGroup>> Handle(GetDataGroupsListQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroups();

        return Task.FromResult(result);
    }
}

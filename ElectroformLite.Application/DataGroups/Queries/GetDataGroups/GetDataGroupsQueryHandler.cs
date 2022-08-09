using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroups;

public class GetDataGroupsQueryHandler : IRequestHandler<GetDataGroupsQuery, List<DataGroup>>
{
    private readonly IDataGroupRepository _repository;

    public GetDataGroupsQueryHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataGroup>> Handle(GetDataGroupsQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroups();

        return Task.FromResult(result);
    }
}

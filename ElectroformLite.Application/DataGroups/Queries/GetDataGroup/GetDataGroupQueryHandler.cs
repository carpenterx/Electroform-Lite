using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroup;

public class GetDataGroupQueryHandler : IRequestHandler<GetDataGroupQuery, DataGroup>
{
    private readonly IDataGroupRepository _repository;

    public GetDataGroupQueryHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<DataGroup> Handle(GetDataGroupQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroup(request.DataGroupId);

        return Task.FromResult(result);
    }
}
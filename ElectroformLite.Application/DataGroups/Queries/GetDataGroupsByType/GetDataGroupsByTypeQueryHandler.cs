using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroups.Queries.GetDataGroupsByType;

public class GetDataGroupsByTypeQueryHandler : IRequestHandler<GetDataGroupsByTypeQuery, List<DataGroup>>
{
    private readonly IDataGroupRepository _repository;

    public GetDataGroupsByTypeQueryHandler(IDataGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<List<DataGroup>> Handle(GetDataGroupsByTypeQuery request, CancellationToken cancellationToken)
    {
        //var result = _repository.GetDataGroupsByType(request.TypeId);
        var result = _repository.GetDataGroups();

        return Task.FromResult(result);
    }
}

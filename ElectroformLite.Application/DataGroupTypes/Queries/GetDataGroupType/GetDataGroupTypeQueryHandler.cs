using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.DataGroupTypes.Queries.GetDataGroupType;

public class GetDataGroupTypeQueryHandler : IRequestHandler<GetDataGroupTypeQuery, DataGroupType>
{
    private readonly IDataGroupTypeRepository _repository;

    public GetDataGroupTypeQueryHandler(IDataGroupTypeRepository repository)
    {
        _repository = repository;
    }

    public Task<DataGroupType> Handle(GetDataGroupTypeQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetDataGroupType(request.DataGroupTypeId);

        return Task.FromResult(result);
    }
}

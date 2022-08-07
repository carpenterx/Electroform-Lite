using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Queries.GetDataList;

public class GetDataListQueryHandler : IRequestHandler<GetDataListQuery, List<Data>>
{
    private readonly IDataRepository _repository;

    public GetDataListQueryHandler(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Data>> Handle(GetDataListQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetAllData();

        return Task.FromResult(result);
    }
}

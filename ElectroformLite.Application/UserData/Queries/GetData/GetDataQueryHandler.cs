using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Queries.GetData;

public class GetDataQueryHandler : IRequestHandler<GetDataQuery, Data>
{
    private readonly IDataRepository _repository;

    public GetDataQueryHandler(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<Data> Handle(GetDataQuery request, CancellationToken cancellationToken)
    {
        var result = _repository.GetData(request.DataId);

        return Task.FromResult(result);
    }
}
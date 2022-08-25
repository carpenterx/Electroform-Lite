using ElectroformLite.Application.Interfaces;
using ElectroformLite.Domain.Models;
using MediatR;

namespace ElectroformLite.Application.UserData.Queries.GetData;

public class GetDataQueryHandler : IRequestHandler<GetDataQuery, Data?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDataQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Data?> Handle(GetDataQuery request, CancellationToken cancellationToken)
    {
        Data? data = await _unitOfWork.DataRepository.GetData(request.DataId);

        return data;
    }
}